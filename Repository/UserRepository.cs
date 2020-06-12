using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly AppSettings _appSettings;

        public UserRepository(RepositoryContext repositoryContext, IOptions<AppSettings> appSettings)
            : base(repositoryContext)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var user = await RepositoryContext.Users.Include(u => u.Citizen).SingleOrDefaultAsync(x => x.UserName == userName);

            // check if user exists
            if (user is null)
                return null;
            
            // check if password is correct
            if (!VerifyPasswordHash(password, user?.PasswordHash, user?.PasswordSalt))
                return null;

            // Generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user?.Id.ToString()),
                    new Claim(ClaimTypes.Role, user?.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await FindAll().Include(u => u.Citizen)
                .OrderBy(user => user.UserName)
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId)).Include(u => u.Citizen)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (RepositoryContext.Users.Any(c => c.UserName == user.UserName))
                throw new Exception("Username \"" + user.UserName + "\" is already taken");

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user.IsActive = true;
            Create(user);
            await SaveAsync();
        }

        public async Task UpdateAsync(User dbUser, User user, string password = null)
        {
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            dbUser.Map(user);
            Update(dbUser);
            await SaveAsync();
        }

        public async Task DeleteAsync(User user)
        {
            user.IsActive = false;
            Update(user);
            await SaveAsync();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException($"password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", $"password");

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException($"password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", $"password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", $"passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", $"passwordHash");

            using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return !computedHash.Where((t, i) => t != storedHash[i]).Any();
        }
    }
}