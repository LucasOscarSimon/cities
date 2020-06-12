using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace States.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/state")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor that receives a logger for logging, a repository and a mapper for mapping objects
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public StateController(ILoggerFactory logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger.CreateLogger("StateLoggerAPI");
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Return all the registered states
        /// </summary>
        /// <returns>Return all the registered states</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllStates()
        {
            try
            {
                var states = await _repository.States.GetAllAsync();

                var statesDtos = _mapper.Map<List<StateDto>>(states);

                _logger.LogInformation($"Returned all states from database.");

                return Ok(statesDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Returns the requested state
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the requested state</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            try
            {
                var state = await _repository.States.GetByIdAsync(id);

                if (state.IsObjectNull())
                {
                    _logger.LogError($"State with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var stateDto = _mapper.Map<StateDto>(state);

                _logger.LogInformation($"Returned state with id: {id}");
                return Ok(stateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetStateById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a state
        /// </summary>
        /// <param name="stateDto"></param>
        /// <returns>Http status code 200</returns>
        [HttpPost]
        public async Task<IActionResult> CreateState([FromBody] StateWithoutIdForCreateDto stateDto)
        {
            try
            {
                if (stateDto is null)
                {
                    _logger.LogError("State object sent from client is null.");
                    return BadRequest("State object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid state object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var state = _mapper.Map<StateWithoutIdForCreateDto, State>(stateDto);
                await _repository.States.CreateAsync(state);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateState action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a state
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stateDto"></param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateState(int id, [FromBody] StateWithoutId stateDto)
        {
            try
            {
                if (stateDto == null)
                {
                    _logger.LogError("State object sent from client is null.");
                    return BadRequest("State object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid state object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var stateDb = await _repository.States.GetByIdAsync(id);

                if (stateDb.IsEmptyObject())
                {
                    _logger.LogError($"State with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var state = _mapper.Map<StateWithoutId, State>(stateDto);

                await _repository.States.UpdateAsync(stateDb, state);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateState action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a state
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            try
            {
                var state = await _repository.States.GetByIdAsync(id);
                if (state.IsEmptyObject())
                {
                    _logger.LogError($"State with id: {id}, hasn't been found in db.");
                    return NotFound();
                }


                await _repository.States.DeleteAsync(state);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteState action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}