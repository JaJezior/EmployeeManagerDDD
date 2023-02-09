using EmployeeManagerDomain.Entities;
using System.Collections.Generic;

namespace EmployeeManagerDomain
{
    public interface IEmployeeRepository
    {
        public List<Employee> Employees { get; set; }
    }
}