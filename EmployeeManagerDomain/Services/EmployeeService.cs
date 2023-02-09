using EmployeeManagerDomain.Entities;
using EmployeeManagerDomain.Models;
using EmployeeManagerDomain.Requests;
using System;
using System.Linq;

namespace EmployeeManagerDomain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _empoloyeeRepository;
        private readonly IEmployeeReferenceNoService _employeeReferenceNoService;

        public EmployeeService(IEmployeeRepository empoloyeeRepository, IEmployeeReferenceNoService employeeReferenceNoService)
        {
            _empoloyeeRepository = empoloyeeRepository;
            _employeeReferenceNoService = employeeReferenceNoService;
        }
        public void CreateNew(AddEmployeeRequest request)
        {
            var newEmployee = new Employee(
                _employeeReferenceNoService.GetNew(),
                new EmployeeName(request.Name),
                new EmployeeGender(int.Parse(request.Gender)));

            _empoloyeeRepository.Employees.Add(newEmployee);
        }

        public void Update(Guid id, UpdateEmployeeRequest request)
        {
            var employeeToEdit = _empoloyeeRepository.Employees.Single(e => e.Id == id);
            employeeToEdit.SetNewData(
                new EmployeeReferenceNo(int.Parse(request.ReferenceNo)),
                new EmployeeName(request.Name),
                new EmployeeGender(request.Gender));
        }
    }
}