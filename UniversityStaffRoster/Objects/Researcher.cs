using System;
using UniversityStaffRoster.Interfaces;

namespace UniversityStaffRoster.Objects
{
    class Researcher : Staff, ITeachable
    {
        private ResearchSpeciality speciality;

        public Researcher(string name) : base(name) { }

        public Researcher(string name, double salary) : base(name, salary) { }

        public Researcher(string name, double salary, Department department) : base(name, salary, department) { }

        public Researcher(string name, double salary, ResearchSpeciality speciality) : base(name, salary) { this.speciality = speciality; }

        public Researcher(string name, double salary, ResearchSpeciality speciality, Department department) : base(name, salary, department) { this.speciality = speciality; }

        public void Teach() => Console.WriteLine($"{Name} is now Researching {speciality} in the {AssignedDepartment.Name} Department!");

        public ResearchSpeciality Speciality { set => speciality = value; get => speciality; }
    }

    public enum ResearchSpeciality { MachineLearning, Calculus, Trigonometry, ComputerVision, Literature, Topology, Biology };
}