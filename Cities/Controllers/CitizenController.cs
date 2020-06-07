using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers
{
    /// <summary>
    /// Citizen operations
    /// </summary>
    [Route("api/citizen")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor with 3 parameters that will help logging comments, get database data and map into other entities
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public CitizenController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all registered citizens
        /// </summary>
        /// <returns>All the registered citizens</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCitizens()
        {
            try
            {
                var citizens = await _repository.Citizens.GetAllAsync();
                foreach (var citizen in citizens)
                    citizen.City = await _repository.Cities.GetByIdAsync(citizen.CityId);

                var citizenDtos = _mapper.Map<IEnumerable<CitizenDto>>(citizens);
                _logger.LogInfo($"Returned all citizens from database.");

                return Ok(citizenDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Returns a specific citizen  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitizenById(int id)
        {
            try
            {
                var citizen = await _repository.Citizens.GetByIdAsync(id);
                citizen.City = await _repository.Cities.GetByIdAsync(citizen.CityId);


                if (citizen.IsEmptyObject())
                {
                    _logger.LogError($"Citizen with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var citizenDto = _mapper.Map<CitizenDto>(citizen);
                
                _logger.LogInfo($"Returned citizen with id: {id}");
                return Ok(citizenDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCitizenById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a citizen
        /// </summary>
        /// <param name="citizenDto"></param>
        /// <returns>Status Code 200</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCitizen([FromBody] CitizenWithoutIdForCreateDto citizenDto)
        {
            try
            {
                if (citizenDto == null)
                {
                    _logger.LogError("Citizen object sent from client is null.");
                    return BadRequest("Citizen object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid citizen object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var citizen = _mapper.Map<CitizenWithoutIdForCreateDto, Citizen>(citizenDto);
                await _repository.Citizens.CreateAsync(citizen);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCitizen action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a citizen
        /// </summary>
        /// <param name="id"></param>
        /// <param name="citizenDto"></param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCitizen(int id, [FromBody] CitizenWithoutIdDto citizenDto)
        {
            try
            {
                if (citizenDto == null)
                {
                    _logger.LogError("Citizen object sent from client is null.");
                    return BadRequest("Citizen object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid citizen object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbCitizen = await _repository.Citizens.GetByIdAsync(id);

                if (dbCitizen.IsObjectNull())
                {
                    _logger.LogError($"Citizen with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var citizen = _mapper.Map<CitizenWithoutIdDto, Citizen>(citizenDto);

                await _repository.Citizens.UpdateAsync(dbCitizen, citizen);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCitizen action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a citizen
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitizen(int id)
        {
            try
            {
                var citizen = await _repository.Citizens.GetByIdAsync(id);
                if (citizen.IsObjectNull())
                {
                    _logger.LogError($"Citizen with id: {id}, hasn't been found in db.");
                    return NotFound();
                }


                await _repository.Citizens.DeleteAsync(citizen);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCitizen action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
