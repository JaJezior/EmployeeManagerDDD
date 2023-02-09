using System;

namespace EmployeeManagerDomain.Models
{
    public record EmployeeName
    {
        public string Name { get; private init; }
        public EmployeeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)}");
            }
            if (name.Length > 50)
            {
                throw new ArgumentException($"{nameof(name)} is too long. Must have 50 or less characters");
            }

            Name = name;
        }
    }
}