using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private ICitizenRepository _citizen;
        private ICityRepository _city;
        private IStateRepository _state;

        // When property is required if it's null, create a new one
        public ICitizenRepository Citizens => _citizen ??= new CitizenRepository(_repoContext);
        public ICityRepository Cities => _city ??= new CityRepository(_repoContext);
        public IStateRepository States => _state ??= new StateRepository(_repoContext);

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}