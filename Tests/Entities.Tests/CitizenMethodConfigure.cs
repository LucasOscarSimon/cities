using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunit;

namespace Entities.Tests
{
    public class CitizenMethodConfigure : ConfigurationBaseTest
    {
        private readonly EntityTypeBuilder<Citizen> _entityTypeBuilder;
        private readonly CitizensConfiguration _citizensConfiguration;
        
        public CitizenMethodConfigure()
        {
            _citizensConfiguration = new CitizensConfiguration();

            _entityTypeBuilder = ModelBuilder.Entity<Citizen>();
            _citizensConfiguration.Configure(_entityTypeBuilder);
        }

        [Fact]
        public void Must_Set_Id_To_Id()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Id));

            //assert
            Assert.Equal("Id", idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Id_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Id));

            //assert
            Assert.False(idProperty.IsNullable);
        }
    }
}
