using EmployeeManagerDomain;
using EmployeeManagerDomain.Entities;
using EmployeeManagerDomain.Models;
using EmployeeManagerDomain.Services;
using FakeItEasy;

namespace EmployeeManagerTests
{
    public class EmployeeTests
    {
        private readonly IEmployeeRepository _repository;
        private readonly List<Employee> _collection;
        private readonly IEmployeeReferenceNoService _referenceNoService;
        public EmployeeTests()
        {
            _collection = new List<Employee>();
            _repository = A.Fake<IEmployeeRepository>();
            A.CallTo(() => _repository.Employees).Returns(_collection);
            _referenceNoService = A.Fake<IEmployeeReferenceNoService>();
            A.CallTo(() => _referenceNoService.GetNew()).Returns(new EmployeeReferenceNo(1));
        }

        [Fact]
        public void ShouldNotCreateEmployee_WhenReferenceNoIsNull()
        {
            //arrange
            EmployeeReferenceNo referenceNo = null;
            EmployeeName name = new("Anon");
            EmployeeGender gender = new(1);
            //act + assert
            Assert.Throws<ArgumentNullException>(() => new Employee(referenceNo, name, gender));
        }

        [Fact]
        public void ShouldNotCreateEmployee_WhenNameIsNull()
        {
            //arrange
            EmployeeReferenceNo referenceNo = _referenceNoService.GetNew();
            EmployeeName name = null;
            EmployeeGender gender = new(1);
            //act + assert
            Assert.Throws<ArgumentNullException>(() => new Employee(referenceNo, name, gender));
        }

        [Fact]
        public void ShouldNotCreateEmployee_WhenGenderIsNull()
        {
            //arrange
            EmployeeReferenceNo referenceNo = _referenceNoService.GetNew();
            EmployeeName name = new("Anon");
            EmployeeGender gender = null;
            //act + assert
            Assert.Throws<ArgumentNullException>(() => new Employee(referenceNo, name, gender));
        }

        [Fact]
        public void ShouldCreateEmployee_WhenDataIsValid()
        {
            //arrange
            EmployeeReferenceNo referenceNo = _referenceNoService.GetNew();
            EmployeeName name = new("Anon");
            EmployeeGender gender = new(1);
            //act
            var employee = new Employee(referenceNo, name, gender);
            //assert
            Assert.Equal("Anon", employee.Name.Name);
            Assert.Equal(Gender.Male, employee.Gender.Gender);
            Assert.Equal("00000001", employee.ReferenceNo.Number);
        }
    }
}