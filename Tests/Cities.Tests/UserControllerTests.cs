using System.Collections.Generic;
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

        public UserControllerTests()
        {
            _mockWrapperRepository = new Mock<IRepositoryWrapper>();
            _mockLoggerFactory = new Mock<ILoggerFactory>();
            var mockLogger = new Mock<ILogger>();
            _mockMapper = new Mock<IMapper>();

            _mockLoggerFactory.Setup(factory => factory.CreateLogger("UsersLoggerApi")).Returns(mockLogger.Object);

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

        public class MethodGetAllUsers : UserControllerTests
        {
            private readonly IActionResult _result;
            private readonly IEnumerable<User> _users;

            public MethodGetAllUsers()
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
                var mockUserRepository = new Mock<IUserRepository>();
                _mockWrapperRepository.Setup(wrapper => wrapper.Users).Returns(mockUserRepository.Object);
                mockUserRepository.Setup(repository => repository.GetAllAsync()).ReturnsAsync(_users);
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
