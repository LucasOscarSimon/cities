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
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await FindAll().Include(s => s.Cities)
                .OrderBy(ow => ow.Name)
                .ToListAsync();
        }

        public async Task<State> GetByIdAsync(int stateId)
        {
            return await FindByCondition(owner => owner.Id.Equals(stateId)).Include(s => s.Cities)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(State state)
        {
            state.IsActive = true;
            Create(state);
            await SaveAsync();
        }

        public async Task UpdateAsync(State dbState, State state)
        {
            dbState.Map(state);
            Update(dbState);
            await SaveAsync();
        }

        public async Task DeleteAsync(State state)
        {
            state.IsActive = false;
            Update(state);
            await SaveAsync();
        }
    }
}