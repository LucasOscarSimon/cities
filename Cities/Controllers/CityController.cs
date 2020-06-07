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
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CityController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _repository.Cities.GetAllAsync();

                var citiesDtos = _mapper.Map<IEnumerable<CityDto>>(cities);
                _logger.LogInfo($"Returned all cities from database.");

                return Ok(citiesDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            try
            {
                var city = await _repository.Cities.GetByIdAsync(id);
                // city.Citizens = await _repository.Citizens.GetByIdAsync(city.);


                if (city.IsEmptyObject())
                {
                    _logger.LogError($"City with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var cityDto = _mapper.Map<CityDto>(city);

                _logger.LogInfo($"Returned city with id: {id}");
                return Ok(cityDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCityById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

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
