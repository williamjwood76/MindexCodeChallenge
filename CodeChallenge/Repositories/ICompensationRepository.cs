using CodeChallenge.Models;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation AddCompensation(Compensation compensation);
        Compensation GetCompensationByEmployeeId(string id);
    }
}