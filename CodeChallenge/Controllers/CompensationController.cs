using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpPost(Name = "addCompensation")]
        public IActionResult AddCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received Compensation create request for '{compensation.employee.EmployeeId}'");

            return Created("CreateCompensation", _compensationService.AddCompensation(compensation));
        }

        [HttpGet("{employeeId}", Name = "getCompensationByEmployeeId")]
        public IActionResult GetCompensationByEmployeeId(string employeeId)
        {
            _logger.LogDebug($"Received Compensation request for '{employeeId}'");

            var compensation = _compensationService.GetCompensationByEmployeeId(employeeId);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }
    }
}
