using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        public ICitizenRepository Citizens { get; }
        public ICityRepository Cities { get; }
        public IStateRepository States { get; }

        public RepositoryWrapper(RepositoryContext repositoryContext, ICitizenRepository citizenRepository, ICityRepository cityRepository, IStateRepository stateRepository)
        {
            _repoContext = repositoryContext;
            Citizens = citizenRepository;
            Cities = cityRepository;
            States = stateRepository;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}