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
    public class CompensationRepository : ICompensationRepository
    {
        private readonly ILogger<ICompensationRepository> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly CompensationContext _compensationContext;

        public CompensationRepository(ILogger<CompensationRepository> logger, IEmployeeService employeeService, CompensationContext compensationContext)
        {
            _logger = logger;
            _employeeService = employeeService;
            _compensationContext = compensationContext;
        }

        public Compensation AddCompensation(Compensation compensation)
        {
            _compensationContext.Add(compensation);
            return compensation;
        }

        public Compensation GetCompensationByEmployeeId(string id)
        {
            if (_employeeService.GetById(id) == null)
                return null;

            return _compensationContext.Compensation.ToList().SingleOrDefault(x => x.employee.EmployeeId == id);
        }
    }
}
