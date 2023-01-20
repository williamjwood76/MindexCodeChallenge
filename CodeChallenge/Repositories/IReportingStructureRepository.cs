using CodeChallenge.Models;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface IReportingStructureRepository
    {
        ReportingStructure GetById(string id);
    }
}