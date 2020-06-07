using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.ExtendedModels;
using Entities.Models;

namespace Contracts
{
    public interface ICityRepository : IRepositoryBase<City>
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City> GetByIdAsync(int? cityId);
        Task<CityExtended> GetCityWithDetailsAsync(int? cityId);
        Task CreateAsync(City city);
        Task UpdateAsync(City dbCity, City city);
        Task DeleteAsync(City city);
    }
}