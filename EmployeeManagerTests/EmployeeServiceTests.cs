using EmployeeManagerDomain;
using EmployeeManagerDomain.Entities;
using EmployeeManagerDomain.Models;
using EmployeeManagerDomain.Requests;
using EmployeeManagerDomain.Services;
using FakeItEasy;

namespace EmployeeManagerTests
{
    public class EmployeeServiceTests
    {
        private readonly IEmployeeRepository _repository;
        private readonly List<Employee> _collection;
        private readonly IEmployeeReferenceNoService _referenceNoService;
        public EmployeeServiceTests()
        {
            _collection = new List<Employee>();
            _repository = A.Fake<IEmployeeRepository>();
            A.CallTo(() => _repository.Employees).Returns(_collection);
            _referenceNoService = A.Fake<IEmployeeReferenceNoService>();
            A.CallTo(() => _referenceNoService.GetNew()).Returns(new EmployeeReferenceNo(1));
        }

        [Fact]
        public void ShouldUpdateEmployee_WhenDataIsCorrect()
        {
            //arrange
            EmployeeReferenceNo referenceNo = new(1);
            EmployeeName name = new("Anon");
            EmployeeGender gender = new(1);

            var employee = new Employee(referenceNo, name, gender);
            _repository.Employees.Add(employee);

            var employeeGuid = _repository.Employees.Single(e => e.ReferenceNo.IntValue == 1).Id;
            var employeeService = new EmployeeService(_repository, _referenceNoService);

            //act
            employeeService.Update(employeeGuid, new UpdateEmployeeRequest()
            {
                Gender = 0,
                Name = "Anon2",
                ReferenceNo = "12345678"
            });

            //assert
            var employeeToCheck = _repository.Employees.Single(e => e.Id == employeeGuid);

            Assert.Equal("Anon2", employeeToCheck.Name.Name);
            Assert.Equal("12345678", employeeToCheck.ReferenceNo.Number);
            Assert.Equal(Gender.Female, employeeToCheck.Gender.Gender);
        }
    }
}