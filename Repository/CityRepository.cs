﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await FindAll()
                .Include(c => c.State)
                .Include(c => c.Citizens)
                .OrderBy(citizen => citizen.Name)
                .ToListAsync();
        }

        public async Task<City> GetByIdAsync(int? cityId)
        {
            return await FindByCondition(city => city.Id.Equals(cityId))
                .Include(c => c.State)
                .Include(c=> c.Citizens)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(City city)
        {
            city.IsActive = true;
            Create(city);
            await SaveAsync();
        }

        public async Task UpdateAsync(City dbCity, City city)
        {
            dbCity.Map(city);
            Update(dbCity);
            await SaveAsync();
        }

        public async Task DeleteAsync(City city)
        {
            city.IsActive = false;
            Update(city);
            await SaveAsync();
        }
    }
}