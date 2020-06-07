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

        public async Task CreateAsync(Citizen citizen)
        {
            citizen.IsActive = true;
            Create(citizen);
            await SaveAsync();
        }

        public async Task UpdateAsync(Citizen dbCitizen, Citizen citizen)
        {
            dbCitizen.Map(citizen);
            Update(dbCitizen);
            await SaveAsync();
        }

        public async Task DeleteAsync(Citizen citizen)
        {
            Delete(citizen);
            await SaveAsync();
        }
    }
}