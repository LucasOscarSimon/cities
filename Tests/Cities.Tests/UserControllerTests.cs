using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Cities.Controllers;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Cities.Tests
{
    public class UserControllerTests
    {
        private readonly UserController _userController;
        private readonly Mock<IRepositoryWrapper> _mockWrapperRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILoggerFactory> _mockLoggerFactory;
        private readonly Mock<ILogger> _mockLogger;

        public UserControllerTests()
        {
            _mockWrapperRepository = new Mock<IRepositoryWrapper>();
            _mockLoggerFactory = new Mock<ILoggerFactory>();
            _mockLogger = new Mock<ILogger>();
            _mockMapper = new Mock<IMapper>();

            _mockLoggerFactory.Setup(factory => factory.CreateLogger("UsersLoggerApi")).Returns(_mockLogger.Object);

            _userController = new UserController(_mockWrapperRepository.Object, _mockMapper.Object, _mockLoggerFactory.Object);
        }

        [Fact]
        public void When_it_is_created_it_must_creates_a_new_ILogger()
        {
            // Arrange

            // Act

            // Assert
            _mockLoggerFactory.Verify(factory => factory.CreateLogger("UsersLoggerApi"), Times.Once);
        }

        public class Method_GetAllUsers : UserControllerTests
        {
            private readonly IActionResult _result;
            private readonly Mock<IUserRepository> _mockUserRepository;
            private readonly IEnumerable<User> _users;

            public Method_GetAllUsers()
            {
                _users = new List<User>
                {
                    new User()
                    {
                        UserName = "Pepe",
                        Role = "Admin"
                    },
                    new User()
                    {
                        UserName = "Jose",
                        Role = "User"
                    },
                };
                _mockUserRepository = new Mock<IUserRepository>();
                _mockWrapperRepository.Setup(wrapper => wrapper.Users).Returns(_mockUserRepository.Object);
                _mockUserRepository.Setup(repository => repository.GetAllAsync()).ReturnsAsync(_users);
                _result = _userController.GetAllUsers().Result;

            }

            [Fact]
            public void When_it_is_called_it_should_returns_OkObjectResult()
            {
                // Arrange

                // Act

                // Assert
                Assert.True(_result is OkObjectResult);
            }

            [Fact]
            public void It_should_call_IMapper_map()
            {
                // Arrange

                // Act

                // Assert
                _mockMapper.Verify(mapper => mapper.Map<IEnumerable<AuthenticatedDto>>(_users), Times.Once);
            }
        }

    }
}
