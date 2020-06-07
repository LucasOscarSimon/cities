using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ICitizenRepository : IRepositoryBase<Citizen>
    {
        Task<IEnumerable<Citizen>> GetAllAsync();
        Task<Citizen> GetByIdAsync(int citizenId);
        // Task<CitizenExtended> GetCitizenWithDetailsAsync(int? citizenId);
        Task CreateAsync(Citizen citizen);
        Task UpdateAsync(Citizen dbCitizen, Citizen citizen);
        Task DeleteAsync(Citizen citizen);
    }
}