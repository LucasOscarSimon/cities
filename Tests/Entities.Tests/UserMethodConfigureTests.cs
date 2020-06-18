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
        public void Must_Set_UserName_To_UserName()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.UserName));

            //assert
            Assert.Equal(nameof(User.UserName), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Token));

            //assert
            Assert.Equal(nameof(User.Token), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.PasswordHash));

            //assert
            Assert.Equal(nameof(User.PasswordHash), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.PasswordSalt));

            //assert
            Assert.Equal(nameof(User.PasswordSalt), idProperty.GetColumnName());
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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.Role));

            //assert
            Assert.Equal(nameof(User.Role), idProperty.GetColumnName());
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
        /// IsActive property validations
        /// </summary>
        [Fact]
        public void Must_Set_IsActive_To_IsActive()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(User.IsActive));

            //assert
            Assert.Equal(nameof(User.IsActive), idProperty.GetColumnName());
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