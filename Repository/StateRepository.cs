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

        public async Task<IEnumerable<State>> GetAll()
        {
            return await FindAll()
                .OrderBy(ow => ow.Name)
                .ToListAsync();
        }

        public async Task<State> GetById(int stateId)
        {
            return await FindByCondition(owner => owner.Id.Equals(stateId))
                .FirstOrDefaultAsync();
        }

        public async Task CreateStateAsync(State state)
        {
            state.IsActive = true;
            Create(state);
            await SaveAsync();
        }

        public async Task UpdateStateAsync(State dbState, State state)
        {
            dbState.Map(state);
            Update(dbState);
            await SaveAsync();
        }

        public async Task DeleteStateAsync(State state)
        {
            Delete(state);
            await SaveAsync();
        }
    }
}