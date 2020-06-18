using Entities.Configurations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Entities.Tests
{
    public class ConfigurationBaseTest
    {
        protected readonly ModelBuilder ModelBuilder;

        public ConfigurationBaseTest()
        {
            // Construct the optionsBuilder using InMemory SqlLite
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(new SqliteConnection("DataSource=:memory:"))
                .Options;

            var usersConfiguration = new UsersConfiguration();
            var citizensConfiguration = new CitizensConfiguration();
            var citiesConfiguration = new CitiesConfiguration();
            var statesConfiguration = new StatesConfiguration();

            var sut = new RepositoryContext(options, usersConfiguration, citizensConfiguration, citiesConfiguration, statesConfiguration);

            // Get the convention set for this db
            var conventionSet = ConventionSet.CreateConventionSet(sut);

            // Now create the ModelBuilder
            ModelBuilder = new ModelBuilder(conventionSet);
        }
    }
}