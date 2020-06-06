namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICitizenRepository Citizens { get; }
        ICityRepository Cities { get; }
        IStateRepository States { get; }
        void Save();
    }
}