using System;

namespace EmployeeManagerDomain.Models
{
    public record EmployeeGender
    {
        public Gender Gender { get; private init; }

        public EmployeeGender(int gender)
        {
            if (!Enum.IsDefined(typeof(Gender), gender))
            {
                throw new ArgumentException($"Cannot resovle value {gender} for {nameof(gender)}");
            }
            Gender = (Gender)gender;
        }
    }

    public enum Gender
    {
        Female = 0, Male = 1
    }
}