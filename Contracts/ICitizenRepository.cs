using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ICitizenRepository : IRepositoryBase<Citizen>
    {
        Citizen Authenticate(string userName, string password);
        Task<IEnumerable<Citizen>> GetAllAsync();
        Task<Citizen> GetByIdAsync(int citizenId);
        Task CreateAsync(Citizen citizen, string password);
        Task UpdateAsync(Citizen dbCitizen, Citizen citizen, string password);
        Task DeleteAsync(Citizen citizen);
    }
}