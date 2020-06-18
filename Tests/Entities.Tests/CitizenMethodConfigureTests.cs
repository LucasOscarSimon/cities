using System.Linq;
using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunit;

namespace Entities.Tests
{
    public class CitizenMethodConfigureTests : ConfigurationBaseTest
    {
        private readonly EntityTypeBuilder<Citizen> _entityTypeBuilder;

        public CitizenMethodConfigureTests()
        {
            var citizensConfiguration = new CitizensConfiguration();

            _entityTypeBuilder = ModelBuilder.Entity<Citizen>();
            citizensConfiguration.Configure(_entityTypeBuilder);
        }

        /// <summary>
        /// Id property validations
        /// </summary>
        [Fact]
        public void Must_Set_Id_To_Id()
        {
            //arrange
            const string idPropName = nameof(Citizen.Id);

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
                .FindDeclaredProperty(nameof(Citizen.Id));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Id_Like_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Id));

            //assert
            Assert.True(idProperty.IsKey());
        }

        /// <summary>
        /// FirstName property validations
        /// </summary>
        [Fact]
        public void Must_Set_FirstName_To_FirstName()
        {
            //arrange
            const string firstNamePropName = nameof(Citizen.FirstName);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(firstNamePropName);

            //assert
            Assert.Equal(firstNamePropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_FirstName_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.FirstName));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_FirstName_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.FirstName));

            //assert
            Assert.False(idProperty.IsKey());
        }

        [Fact]
        public void Must_Set_FirstName_Max_Length_250()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.FirstName));

            //assert
            Assert.Equal(250, idProperty.GetMaxLength());
        }

        /// <summary>
        /// LastName property validations
        /// </summary>
        [Fact]
        public void Must_Set_LastName_To_LastName()
        {
            //arrange
            const string lastNamePropName = nameof(Citizen.LastName);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(lastNamePropName);

            //assert
            Assert.Equal(lastNamePropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_LastName_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.LastName));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_LastName_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.LastName));

            //assert
            Assert.False(idProperty.IsKey());
        }

        [Fact]
        public void Must_Set_LastName_Max_Length_250()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.LastName));

            //assert
            Assert.Equal(250, idProperty.GetMaxLength());
        }

        /// <summary>
        /// Document property validations
        /// </summary>
        [Fact]
        public void Must_Set_Document_To_Document()
        {
            //arrange
            const string documentPropName = nameof(Citizen.Document);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(documentPropName);

            //assert
            Assert.Equal(documentPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Document_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Document));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Document_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Document));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// Address property validations
        /// </summary>
        [Fact]
        public void Must_Set_Address_To_Address()
        {
            //arrange
            const string addressPropName = nameof(Citizen.Address);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(addressPropName);

            //assert
            Assert.Equal(addressPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Address_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Address));

            //assert
            Assert.True(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Address_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Address));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// Email property validations
        /// </summary>
        [Fact]
        public void Must_Set_Email_To_Email()
        {
            //arrange
            const string emailPropName = nameof(Citizen.Email);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(emailPropName);

            //assert
            Assert.Equal(emailPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Email_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Email));

            //assert
            Assert.True(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Email_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Email));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// City property validations
        /// </summary>
        [Fact]
        public void Must_Set_CityId_To_CityId()
        {
            //arrange
            const string cityIdPropName = nameof(Citizen.CityId);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(cityIdPropName);

            //assert
            Assert.Equal(cityIdPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_CityId_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.CityId));

            //assert
            Assert.True(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_CityId_Like_ForeignKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.CityId));

            //assert
            Assert.True(idProperty.IsForeignKey());
        }

        /// <summary>
        /// City property validations
        /// </summary>
        [Fact]
        public void Must_Set_City_To_City()
        {
            //arrange
            const string cityPropName = nameof(Citizen.City);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(cityPropName);

            //assert
            Assert.Equal(cityPropName, idProperty.Name);
        }

        [Fact]
        public void Must_Set_City_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(Citizen.City));

            //assert
            Assert.NotNull(idProperty);
        }

        [Fact]
        public void Must_Set_City_Like_Is_Dependent_To_Principal()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(Citizen.City));

            //assert
            Assert.True(idProperty.IsDependentToPrincipal());
        }

        /// <summary>
        /// IsActive property validations
        /// </summary>
        [Fact]
        public void Must_Set_IsActive_To_IsActive()
        {
            //arrange
            const string isActivePropName = nameof(Citizen.IsActive);

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
                .FindDeclaredProperty(nameof(Citizen.IsActive));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_IsActive_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.IsActive));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// UserId property validations
        /// </summary>
        [Fact]
        public void Must_Set_UserId_To_UserId()
        {
            //arrange
            const string userIdPropName = nameof(Citizen.UserId);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(userIdPropName);

            //assert
            Assert.Equal(userIdPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_UserId_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.UserId));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_UserId_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.UserId));

            //assert
            Assert.False(idProperty.IsKey());
        }
        
        /// <summary>
        /// The table should contain 'x' properties
        /// </summary>
        [Fact]
        public void Only_Contains_9_Properties()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .GetProperties();

            //assert
            Assert.Equal(9, idProperty.Count());
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
            Assert.Equal(nameof(Citizen), tableName);
        }
    }
}
