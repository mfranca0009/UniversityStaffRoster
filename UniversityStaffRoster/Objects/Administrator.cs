using System;
using UniversityStaffRoster.Interfaces;

namespace UniversityStaffRoster.Objects
{
    class Administrator : Staff, IAdmin
    {
        public Administrator(string name) : base(name) { }

        public Administrator(string name, double salary) : base(name, salary) { }

        public Administrator(string name, double salary, Department department) : base(name, salary, department) { }

        public void Administrate() => Console.WriteLine($"{Name} is now administrating in the {AssignedDepartment.Name} Department!");
    }
}
