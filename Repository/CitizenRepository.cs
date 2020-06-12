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
    public class CitizenRepository : RepositoryBase<Citizen>, ICitizenRepository
    {

        public CitizenRepository(RepositoryContext repositoryContext, IOptions<AppSettings> appSettings)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Citizen>> GetAllAsync()
        {
            return await FindAll().Include(c => c.City)
                .OrderBy(citizen => citizen.FirstName)
                .ToListAsync();
        }

        public async Task<Citizen> GetByIdAsync(int citizenId)
        {
            return await FindByCondition(citizen => citizen.Id.Equals(citizenId)).Include(c => c.City)
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
            citizen.IsActive = false;
            Update(citizen);
            await SaveAsync();
        }
    }
}