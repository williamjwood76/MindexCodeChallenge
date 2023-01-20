using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository CompensationRepository)
        {
            _compensationRepository = CompensationRepository;
            _logger = logger;
        }

        public Compensation AddCompensation(Compensation compensation)
        {
            _compensationRepository.AddCompensation(compensation);
            return compensation;
        }

        public Compensation GetCompensationByEmployeeId(string id)
        {
            return _compensationRepository.GetCompensationByEmployeeId(id);
        }
    }
}
