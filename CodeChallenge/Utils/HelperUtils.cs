using CodeChallenge.Services;
using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Utils
{
    public static class HelperUtils
    {
        public static List<Employee> FixUpReferences(this List<Employee> employees)
        {
            var employeeIdRefMap = from employee in employees
                                   select new { Id = employee.EmployeeId, EmployeeRef = employee };

            employees.ForEach(employee =>
            {
                if (employee.DirectReports != null)
                {
                    var referencedEmployees = new List<Employee>(employee.DirectReports.Count);
                    employee.DirectReports.ForEach(report =>
                    {
                        var referencedEmployee = employeeIdRefMap.First(e => e.Id == report.EmployeeId).EmployeeRef;
                        referencedEmployees.Add(referencedEmployee);
                    });
                    employee.DirectReports = referencedEmployees;
                }
            });
            return employees;
        }
    }
}