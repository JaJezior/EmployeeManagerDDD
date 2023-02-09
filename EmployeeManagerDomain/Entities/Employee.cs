using EmployeeManagerDomain.Models;
using System;

namespace EmployeeManagerDomain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public EmployeeReferenceNo ReferenceNo { get; private set; }
        public EmployeeName Name { get ; private set; }
        public EmployeeGender Gender { get ; private set; }

        public Employee(EmployeeReferenceNo referenceNo, EmployeeName name, EmployeeGender gender)
        {
            Id = Guid.NewGuid();
            SetNewData(referenceNo, name, gender);
        }

        public void SetNewData(EmployeeReferenceNo employeeReferenceNo, EmployeeName employeeName, EmployeeGender employeeGender)
        {
            ReferenceNo = employeeReferenceNo ?? throw new ArgumentNullException(nameof(employeeReferenceNo)); ;
            Name = employeeName ?? throw new ArgumentNullException(nameof(employeeName));
            Gender = employeeGender ?? throw new ArgumentNullException(nameof(employeeGender));
        }
    }
}