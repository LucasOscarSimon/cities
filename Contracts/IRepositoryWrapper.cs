namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository Users { get; }
        ICitizenRepository Citizens { get; }
        ICityRepository Cities { get; }
        IStateRepository States { get; }
        void Save();
    }
}