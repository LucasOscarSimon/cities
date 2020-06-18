using System.Linq;
using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunit;

namespace Entities.Tests
{
    public class StateMethodConfigureTests : ConfigurationBaseTest
    {
        private readonly EntityTypeBuilder<State> _entityTypeBuilder;

        public StateMethodConfigureTests()
        {
            var citizensConfiguration = new StatesConfiguration();

            _entityTypeBuilder = ModelBuilder.Entity<State>();
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
                .FindDeclaredProperty(nameof(State.Id));

            //assert
            Assert.Equal("Id", idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Id_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.Id));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Id_Like_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.Id));

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

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.Name));

            //assert
            Assert.Equal(nameof(State.Name), idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_Name_Like_Not_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.Name));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_Name_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.Name));

            //assert
            Assert.False(idProperty.IsKey());
        }

        [Fact]
        public void Must_Set_IsActive_To_IsActive()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.IsActive));

            //assert
            Assert.Equal(nameof(State.IsActive), idProperty.GetColumnName());
        }

        [Fact]
        public void Must_Set_IsActive_Like_Null()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.IsActive));

            //assert
            Assert.False(idProperty.IsNullable);
        }

        [Fact]
        public void Must_Set_IsActive_Like_No_PrimaryKey()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .FindDeclaredProperty(nameof(State.IsActive));

            //assert
            Assert.False(idProperty.IsKey());
        }

        /// <summary>
        /// The table should contain 'x' properties
        /// </summary>
        [Fact]
        public void Only_Contains_3_Properties()
        {
            //arrange

            //act
            var idProperty = _entityTypeBuilder.Metadata
                .GetProperties();

            //assert
            Assert.Equal(3, idProperty.Count());
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
            Assert.Equal(nameof(State), tableName);
        }
    }
}