using System.Linq;
using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunit;

namespace Entities.Tests
{
    public class UserMethodConfigureTests : ConfigurationBaseTest
    {
        private readonly EntityTypeBuilder<User> _entityTypeBuilder;

        public UserMethodConfigureTests()
        {
            var citizensConfiguration = new UsersConfiguration();

            _entityTypeBuilder = ModelBuilder.Entity<User>();
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
                .FindDeclaredProperty(nameof(User.Id));

            //assert
            Assert.Equal("Id", idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Id_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Id));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Id_Like_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Id));

            //assert
            Assert.True(idProperty.IsKey());
        }

        /// <summary>
        /// UserName property validations
        /// </summary>
        [Fact]
        public void Must_Set_UserName_Max_Length_250()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.UserName));

            //assert
            Assert.Equal(250, idProperty.GetMaxLength());
        }

        [Fact]
        public void Must_Set_UserName_To_UserName()
        {
            //arrange
            const string userNamePropName = nameof(User.UserName);
            
            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(userNamePropName);

            //assert
            Assert.Equal(userNamePropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_UserName_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.UserName));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_UserName_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.UserName));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// Token property validations
        /// </summary>
        [Fact]
        public void Must_Set_Token_To_Token()
        {
            //arrange
            const string tokenName = nameof(User.Token);
            
            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(tokenName);

            //assert
            Assert.Equal(tokenName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Token_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Token));

            //assert
            Assert.True(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Token_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Token));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// PasswordHash property validations
        /// </summary>
        [Fact]
        public void Must_Set_PasswordHash_To_PasswordHash()
        {
            //arrange
            const string passwordHashPropName = nameof(User.PasswordHash);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(passwordHashPropName);

            //assert
            Assert.Equal(passwordHashPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_PasswordHash_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.PasswordHash));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_PasswordHash_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.PasswordHash));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// PasswordSalt property validations
        /// </summary>
        [Fact]
        public void Must_Set_PasswordSalt_To_PasswordSalt()
        {
            //arrange
            const string passwordSaltPropName = nameof(User.PasswordSalt);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(passwordSaltPropName);

            //assert
            Assert.Equal(passwordSaltPropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_PasswordSalt_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.PasswordSalt));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_PasswordSalt_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.PasswordSalt));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// Role property validations
        /// </summary>
        [Fact]
        public void Must_Set_Role_To_Role()
        {
            //arrange
            const string rolePropName = nameof(User.Role);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(rolePropName);

            //assert
            Assert.Equal(rolePropName, idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Role_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Role));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Role_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Role));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// Citizen property validations
        /// </summary>
        [Fact]
        public void Must_Set_Citizen_To_Citizen()
        {
            //arrange
            const string citizenPropName = nameof(User.Citizen);

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(citizenPropName);

            //assert
            Assert.Equal(citizenPropName, idProperty.Name);
        }

        [Fact]
        public void Must_Set_Citizen_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(User.Citizen));

            //assert
            Assert.NotNull(idProperty);
        }

        [Fact]
        public void Must_Set_Citizen_Like_Is_Not_Dependent_To_Principal()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredNavigation(nameof(User.Citizen));

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
            const string isActivePropName = nameof(User.IsActive);

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
                .FindDeclaredProperty(nameof(User.IsActive));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_IsActive_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.IsActive));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// The table should contain 'x' properties
        /// </summary>
        [Fact]
        public void Only_Contains_7_Properties()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .GetProperties();

            //assert
            Assert.Equal(7, idProperty.Count());
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
            Assert.Equal(nameof(User), tableName);
        }
    }
}