using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
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

        public async Task<IEnumerable<Citizen>> GetAll()
        {
            return await FindAll()
                .OrderBy(ow => ow.FullName)
                .ToListAsync();
        }
    }
}