using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers
{
    [Route("api/citizen")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;

        public CitizenController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCitizens()
        {
            try
            {
                var citizens = await _repository.Citizens.GetAll();

                _logger.LogInfo($"Returned all citizens from database.");

                return Ok(citizens);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAll action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
