using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IStateRepository : IRepositoryBase<State>
    {
        Task<IEnumerable<State>> GetAllAsync();
        Task<State> GetByIdAsync(int stateId);
        Task CreateAsync(State state);
        Task UpdateAsync(State dbState, State state);
        Task DeleteAsync(State state);
    }
}