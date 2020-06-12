using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cities.Controllers
{
    /// <summary>
    /// User operations
    /// </summary>
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor with 3 parameters that will help logging comments, get database data and map into other entities
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public UserController(IRepositoryWrapper repository, IMapper mapper, ILoggerFactory logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger.CreateLogger("UsersLoggerApi");
        }

        /// <summary>
        /// Authenticates the user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateDto dto)
        {
            try
            {
                var user = await _repository.Users.Authenticate(dto.Username, dto.Password);
                if (user is null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var userDto = _mapper.Map<AuthenticatedDto>(user);

                _logger.LogInformation($"User successfully authenticated.");
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        /// <summary>
        /// Returns all registered users
        /// </summary>
        /// <returns>All the registered users</returns>
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _repository.Users.GetAllAsync();

                var usersDtos = _mapper.Map<IEnumerable<AuthenticatedDto>>(users);
                _logger.LogInformation($"Returned all users from database.");

                return Ok(usersDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Returns a specific user  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                if (User == null)
                    return Unauthorized();
                //
                // var currentUserId = int.Parse(User.Identity.Name);
                // if (id != currentUserId && !User.IsInRole(Role.Admin))
                //     return Forbid();

                var user = await _repository.Users.GetByIdAsync(id);
                var userDto = _mapper.Map<AuthenticatedDto>(user);

                _logger.LogInformation($"Returned user with id: {id}");
                return Ok(userDto);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>Status Code 200</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserWithoutIdForCreateDto userDto)
        {
            try
            {
                if (userDto == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid dto object");
                }

                var user = _mapper.Map<UserWithoutIdForCreateDto, User>(userDto);
                var citizen = _mapper.Map<UserWithoutIdForCreateDto, Citizen>(userDto);
                await _repository.Users.CreateAsync(user, userDto.Password);
                citizen.UserId = user.Id;
                await _repository.Citizens.CreateAsync(citizen);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDto"></param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserWithoutIdDto userDto)
        {
            try
            {
                if (userDto is null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid dto object");
                }

                var dbUser = await _repository.Users.GetByIdAsync(id);

                if (dbUser is null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var user = _mapper.Map<UserWithoutIdDto, User>(userDto);

                await _repository.Users.UpdateAsync(dbUser, user, userDto.Password);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _repository.Users.GetByIdAsync(id);
                if (user is null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await _repository.Users.DeleteAsync(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
