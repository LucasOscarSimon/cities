using System.Linq;
using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunit;

namespace Entities.Tests
{
    public class CityMethodConfigureTests : ConfigurationBaseTest
    {
        private readonly EntityTypeBuilder<City> _entityTypeBuilder;

        public CityMethodConfigureTests()
        {
            var citizensConfiguration = new CitiesConfiguration();

            _entityTypeBuilder = ModelBuilder.Entity<City>();
            citizensConfiguration.Configure(_entityTypeBuilder);
        }

        /// <summary>
        /// Id property validations
        /// </summary>
        [Fact]
        public void Must_Set_Id_To_Id()
        {
            //arrange
            const string idPropName = nameof(City.Id);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(idPropName);

            //assert
            Assert.Equal(idPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Id_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.Id));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Id_Like_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.Id));

            //assert
            Assert.True(idProperty.IsKey());
        }

        /// <summary>
        /// Name property validations
        /// </summary>
        [Fact]
        public void Must_Set_Name_To_Name()
        {
            //arrange
            const string namePropName = nameof(City.Name);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(namePropName);

            //assert
            Assert.Equal(namePropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Name_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.Name));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Name_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.Name));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// StateId property validations
        /// </summary>
        [Fact]
        public void Must_Set_StateId_To_StateId()
        {
            //arrange
            const string stateIdPropName = nameof(City.StateId);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(stateIdPropName);

            //assert
            Assert.Equal(stateIdPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_StateId_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.StateId));

            //assert
            Assert.True(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_StateId_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.StateId));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// State property validations
        /// </summary>
        [Fact]
        public void Must_Set_State_To_State()
        {
            //arrange
            const string statePropName = nameof(City.State);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(statePropName);

            //assert
            Assert.Equal(statePropName, idProperty.Name);
        }

        [Fact]
        public void Must_Set_State_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(City.State));

            //assert
            Assert.NotNull(idProperty);
        }

        [Fact]
        public void Must_Set_State_Like_Is_Dependent_To_Principal()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(City.State));

            //assert
            Assert.True(idProperty.IsDependentToPrincipal());
        }

        /// <summary>
        /// Citizens property validations
        /// </summary>
        [Fact]
        public void Must_Set_Citizens_As_Collection()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(City.Citizens));

            //assert
            Assert.True(idProperty.IsCollection());
        }

        [Fact]
        public void Must_Set_Citizens_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(City.Citizens));

            //assert
            Assert.NotNull(idProperty);
        }

        [Fact]
        public void Must_Set_Citizens_Like_Is_Not_Dependent_To_Principal()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(City.Citizens));

            //assert
            Assert.False(idProperty.IsDependentToPrincipal());
        }

        /// <summary>
        /// IsActive property validations
        /// </summary>
        [Fact]
        public void Must_Set_IsActive_To_IsActive()
        {
            //arrange
            const string isActivePropName = nameof(City.IsActive);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(isActivePropName);

            //assert
            Assert.Equal(isActivePropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_IsActive_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.IsActive));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_IsActive_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(City.IsActive));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// The table should contain 'x' properties
        /// </summary>
        [Fact]
        public void Only_Contains_4_Properties()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .GetProperties();

            //assert
            Assert.Equal(4, idProperty.Count());
        }

        /// <summary>
        /// Table name test
        /// </summary>
        [Fact]
        public void Must_Set_Article_As_Table_Name()
        {
            //arrange

            //act
            var tableName = _entityTypeBuilder.Metadata.GetTableName();

            //assert
            Assert.Equal(nameof(City), tableName);
        }
    }
}
