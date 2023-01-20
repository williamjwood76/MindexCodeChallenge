using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Data;
using CodeChallenge.Models;
using CodeChallenge.Services;
using CodeChallenge.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Repositories
{
    public class ReportingStructureRepository : IReportingStructureRepository
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<IReportingStructureRepository> _logger;

        public ReportingStructureRepository(ILogger<ReportingStructureRepository> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public ReportingStructure GetById(string id)
        {
            Employee employee = _employeeService.GetById(id);

            if (employee == null) 
                return null;

            return new ReportingStructure
            {
                employee = employee,
                numberOfReports = employee.DirectReports?.Count ?? 0
            };
        }
    }
}
