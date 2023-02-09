using EmployeeManagerDomain.Models;
using System.Linq;

namespace EmployeeManagerDomain.Services
{
    public class EmployeeReferenceNoService : IEmployeeReferenceNoService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeReferenceNoService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public EmployeeReferenceNo GetNew()
        {
            var highestCurrentValue = 0;

            if (_repository.Employees.Any())
            {
                highestCurrentValue = _repository.Employees.Max(e => e.ReferenceNo.IntValue);
            }
            return new EmployeeReferenceNo(highestCurrentValue + 1);
        }
    }
}