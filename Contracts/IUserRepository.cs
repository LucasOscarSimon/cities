using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> Authenticate(string email, string password);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int userId);
        Task CreateAsync(User user, string password);
        Task UpdateAsync(User dbUser, User user, string password);
        Task DeleteAsync(User user);
    }
}