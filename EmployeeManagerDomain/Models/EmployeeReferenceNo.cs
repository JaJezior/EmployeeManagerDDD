using System;

namespace EmployeeManagerDomain.Models
{
    public record EmployeeReferenceNo
    {
        public string Number => IntValue.ToString("00000000");
        public int IntValue { get; private init; }
        public EmployeeReferenceNo(int number)
        {
            if (number > 99999999)
            {
                throw new ArgumentException($"Number {number} exceeds maximum value for 8-digit code");
            }
            IntValue = number;
        }
    }
}