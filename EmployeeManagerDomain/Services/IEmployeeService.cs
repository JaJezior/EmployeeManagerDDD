using EmployeeManagerDomain.Requests;
using System;

namespace EmployeeManagerDomain.Services
{
    public interface IEmployeeService
    {
        public void CreateNew(AddEmployeeRequest request);
        public void Update(Guid id, UpdateEmployeeRequest request);
    }
}