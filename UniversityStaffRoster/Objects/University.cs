using System;

namespace UniversityStaffRoster.Objects 
{
     class University 
     {
        private string universityName;
        private int departmentTotal;
        private Department[] departments;

        public University() { }

        public University(string universityName) { this.universityName = universityName; }
        public University(int departmentTotal) { this.departmentTotal = departmentTotal; }

        public University(string universityName, int departmentTotal)
        {
            this.universityName = universityName;
            this.departmentTotal = departmentTotal;
        }

        public void InitializeDepartments()
        {
            departments = new Department[departmentTotal];
        }

        public void DisplayStaffRoster()
        {
            Console.WriteLine("\nUniversity Staff Roster");
            Console.WriteLine("--------------------------------------\n");

            for (int i = 0; i < departmentTotal; i++)
            {
                for (int j = 0; j < departments[i].TotalStaff; j++)
                {
                    switch (departments[i].Staff[j].GetType().Name.ToString())
                    {
                        case "Researcher":
                            {
                                Console.WriteLine(departments[i].Staff[j].Name);
                                Console.WriteLine($"Department: {departments[i].Staff[j].AssignedDepartment.Name}");
                                Console.WriteLine(departments[i].Staff[j].Salary);
                                Console.WriteLine($"Research Speciality: {departments[i].Staff[j].ToResearcher().Speciality}");
                                Console.WriteLine("\n--------------------------------------\n");
                                break;
                            }
                        case "Professor":
                            {
                                Console.WriteLine(departments[i].Staff[j].Name);
                                Console.WriteLine($"Department: {departments[i].Staff[j].AssignedDepartment.Name}");
                                Console.WriteLine(departments[i].Staff[j].Salary);
                                Console.WriteLine($"Class: {departments[i].Staff[j].ToProfessor().ClassTaught}");
                                departments[i].Staff[j].ToProfessor().Teach();
                                Console.WriteLine("\n--------------------------------------\n");
                                break;
                            }
                        case "Dean":
                            {
                                Console.WriteLine(departments[i].Staff[j].Name);
                                Console.WriteLine($"Department: {departments[i].Staff[j].AssignedDepartment.Name}");
                                Console.WriteLine(departments[i].Staff[j].Salary);
                                Console.WriteLine($"Class: {departments[i].Staff[j].ToDean().ClassTaught}");

                                if (departments[i].Staff[j].ToDean().ClassTaught != "None")
                                {
                                    departments[i].Staff[j].ToDean().Teach();
                                }

                                departments[i].Staff[j].ToDean().Administrate();
                                Console.WriteLine("\n--------------------------------------\n");
                                break;
                            }
                        case "Administrator":
                            {
                                Console.WriteLine(departments[i].Staff[j].Name);
                                Console.WriteLine($"Department: {departments[i].Staff[j].AssignedDepartment.Name}");
                                Console.WriteLine(departments[i].Staff[j].Salary);
                                departments[i].Staff[j].ToAdministrator().Administrate();
                                Console.WriteLine("\n--------------------------------------\n");
                                break;
                            }
                    }
                }
            }
        }

        public string Name { set => universityName = value; get => universityName; }

        public int TotalDepartments { set => departmentTotal = value; get => departmentTotal; }

        public Department[] Department{ get => departments; }
    }
}
