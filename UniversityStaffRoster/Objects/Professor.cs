using System;
using UniversityStaffRoster.Interfaces;

namespace UniversityStaffRoster.Objects
{
    class Professor : Staff, ITeachable
    {
        string classTaught;

        public Professor(string name, string classTaught) : base(name) { this.classTaught = classTaught; }
        public Professor(string name, string classTaught, double salary) : base(name, salary) { this.classTaught = classTaught; }

        public Professor(string name, string classTaught, double salary, Department department) : base(name, salary, department) { this.classTaught = classTaught; }

        public string ClassTaught { set => classTaught = value; get => classTaught; }

        public void Teach() => Console.WriteLine($"{Name} is now teaching {ClassTaught} in the {AssignedDepartment.Name} Department!");
    }
}
