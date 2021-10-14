using System;

namespace UniversityStaffRoster.Objects
{
    class Staff
    {
        private string name;
        private double salary;
        private Department department;

        public Staff(string name)
        {

            this.name = name;
            this.salary = 0.00;

        }

        public Staff(string name, double salary)
        {

            this.name = name;
            this.salary = salary;

        }

        public Staff(string name, double salary, Department department)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
        }

        public Researcher ToResearcher()
        {
            return (Researcher)this;
        }

        public Administrator ToAdministrator()
        {
            return (Administrator)this;
        }

        public Dean ToDean()
        {
            return (Dean)this;
        }

        public Professor ToProfessor()
        {
            return (Professor)this;
        }

        public string Name { get => this.GetType().Name + " " + name; }
        public string Salary { get => String.Format("Salary: {0:C}", salary); }

        public Department AssignedDepartment { set => department = value; get => department; }
    }
}
