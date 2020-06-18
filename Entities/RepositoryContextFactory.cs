using Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder
                .UseSqlServer(config.GetConnectionString("connectionString:MyConnection"));

            return new RepositoryContext(optionsBuilder.Options, 
                new UsersConfiguration(), 
                new CitizensConfiguration(), 
                new CitiesConfiguration(), 
                new StatesConfiguration());
        }
    }
}