using System;
using UniversityStaffRoster.Interfaces;

namespace UniversityStaffRoster.Objects
{
    class Dean : Staff, ITeachable, IAdmin
    {
        // "None" by default
        string classTaught = "None";

        public Dean(string name) : base(name) { }

        public Dean(string name, double salary) : base(name, salary) { }

        public Dean(string name, double salary, Department department) : base(name, salary, department) { }

        public Dean(string name, double salary, string classTaught) : base(name, salary) { this.classTaught = classTaught; }

        public Dean(string name, double salary, string classTaught, Department department) : base(name, salary, department) { this.classTaught = classTaught; }

        public string ClassTaught { set => classTaught = value; get => classTaught; }

        public void Teach() => Console.WriteLine($"{Name} is now teaching {ClassTaught} in the {AssignedDepartment.Name} Department!");

        public void Administrate() => Console.WriteLine($"{Name} is now administrating in the {AssignedDepartment.Name} Department!");
    }
}
