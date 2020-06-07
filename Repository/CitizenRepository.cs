using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CitizenRepository : RepositoryBase<Citizen>, ICitizenRepository
    {
        public CitizenRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Citizen Authenticate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var citizen = RepositoryContext.Citizens.SingleOrDefault(x => x.FullName == userName);

            // check if citizen exists
            if (citizen.IsObjectNull())
                return null;

            // check if password is correct & authenticate!
            return !VerifyPasswordHash(password, citizen?.PasswordHash, citizen?.PasswordSalt) ? null : citizen;
        }

        public async Task<IEnumerable<Citizen>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(citizen => citizen.FullName)
                .ToListAsync();
        }

        public async Task<Citizen> GetByIdAsync(int citizenId)
        {
            return await FindByCondition(citizen => citizen.Id.Equals(citizenId))
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Citizen citizen, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (RepositoryContext.Citizens.Any(c => c.FullName == citizen.FullName))
                throw new Exception("Username \"" + citizen.FullName + "\" is already taken");

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            citizen.PasswordHash = passwordHash;
            citizen.PasswordSalt = passwordSalt;

            citizen.IsActive = true;
            Create(citizen);
            await SaveAsync();
        }

        public async Task UpdateAsync(Citizen dbCitizen, Citizen citizen, string password = null)
        {
            var citizenExists = FindByCondition(c => c.FullName == citizen.FullName);
            if(citizenExists == null)
                throw new Exception("Citizen not found");

            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
                citizen.PasswordHash = passwordHash;
                citizen.PasswordSalt = passwordSalt;
            }

            dbCitizen.Map(citizen);
            Update(dbCitizen);
            await SaveAsync();
        }

        public async Task DeleteAsync(Citizen citizen)
        {
            Delete(citizen);
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