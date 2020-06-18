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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.FirstName));

            //assert
            Assert.Equal(nameof(Citizen.FirstName), idProperty.GetColumnName());
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

        /// <summary>
        /// LastName property validations
        /// </summary>
        [Fact]
        public void Must_Set_LastName_To_LastName()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.LastName));

            //assert
            Assert.Equal(nameof(Citizen.LastName), idProperty.GetColumnName());
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

        /// <summary>
        /// Document property validations
        /// </summary>
        [Fact]
        public void Must_Set_Document_To_Document()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Document));

            //assert
            Assert.Equal(nameof(Citizen.Document), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Address));

            //assert
            Assert.Equal(nameof(Citizen.Address), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.Email));

            //assert
            Assert.Equal(nameof(Citizen.Email), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.CityId));

            //assert
            Assert.Equal(nameof(Citizen.CityId), idProperty.GetColumnName());
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
        /// IsActive property validations
        /// </summary>
        [Fact]
        public void Must_Set_IsActive_To_IsActive()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.IsActive));

            //assert
            Assert.Equal(nameof(Citizen.IsActive), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(Citizen.UserId));

            //assert
            Assert.Equal(nameof(Citizen.UserId), idProperty.GetColumnName());
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
