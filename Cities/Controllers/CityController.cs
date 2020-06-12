using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cities.Controllers
{
    /// <summary>
    /// City related operations
    /// </summary>
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
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
        public CityController(ILoggerFactory logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger.CreateLogger("CityLoggerAPI");
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Return all the registered cities
        /// </summary>
        /// <returns>Return all the registered cities</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _repository.Cities.GetAllAsync();

                var citiesDtos = _mapper.Map<List<CityDto>>(cities);

                _logger.LogInformation($"Returned all cities from database.");

                return Ok(citiesDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Returns the requested city
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the requested city</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            try
            {
                var city = await _repository.Cities.GetByIdAsync(id);

                if (city.IsEmptyObject())
                {
                    _logger.LogError($"City with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var cityDto = _mapper.Map<CityDto>(city);

                _logger.LogInformation($"Returned city with id: {id}");
                return Ok(cityDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCityById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a city
        /// </summary>
        /// <param name="cityDto"></param>
        /// <returns>Http status code 200</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CityWithoutIdForCreateDto cityDto)
        {
            try
            {
                if (cityDto == null)
                {
                    _logger.LogError("City object sent from client is null.");
                    return BadRequest("City object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid city object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var city = _mapper.Map<CityWithoutIdForCreateDto, City>(cityDto);
                await _repository.Cities.CreateAsync(city);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCity action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a city
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cityDto"></param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityWithoutId cityDto)
        {
            try
            {
                if (cityDto == null)
                {
                    _logger.LogError("City object sent from client is null.");
                    return BadRequest("City object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid city object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var cityDb = await _repository.Cities.GetByIdAsync(id);

                if (cityDb.IsEmptyObject())
                {
                    _logger.LogError($"City with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var city = _mapper.Map<CityWithoutId, City>(cityDto);

                await _repository.Cities.UpdateAsync(cityDb, city);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCity action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a city
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                var city = await _repository.Cities.GetByIdAsync(id);
                if (city.IsEmptyObject())
                {
                    _logger.LogError($"City with id: {id}, hasn't been found in db.");
                    return NotFound();
                }


                await _repository.Cities.DeleteAsync(city);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCity action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
