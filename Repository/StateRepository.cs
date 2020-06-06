using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}