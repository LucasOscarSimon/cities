using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ICitizenRepository : IRepositoryBase<Citizen>
    {
        Task<IEnumerable<Citizen>> GetAll();
    }
}