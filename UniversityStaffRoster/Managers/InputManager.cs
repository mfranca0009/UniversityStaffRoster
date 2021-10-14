using System;

namespace UniversityStaffRoster.Managers
{
    class InputManager
    {
        public InputManager() { }

        public string RetrieveUniversityName()
        {
            Console.Write("\nEnter the name of this university: ");
            string universityName = Console.ReadLine();

            while (universityName.Length == 0)
            {
                Console.WriteLine("Invalid input, university name must be at least one character! Try again.");
                Console.Write("\nEnter the name of this university: ");
                universityName = Console.ReadLine();
            }

            return universityName;
        }

        public string RetrieveDepartmentName(int index)
        {
            Console.Write($"Enter the name for Department #{index + 1}: ");
            string departmentName = Console.ReadLine();

            while (departmentName.Length == 0)
            {
                Console.WriteLine("Invalid input, department name must contain at least one character! Try again.\n");
                Console.Write($"\nEnter the name for Department {index + 1}: ");
                departmentName = Console.ReadLine();
            }

            return departmentName;
        }

        public string RetrieveStaffMemberName(int index)
        {
            Console.Write($"\nEnter name of Staff Member {index + 1}: ");
            string staffName = Console.ReadLine();

            while (staffName.Length == 0)
            {
                Console.WriteLine("Invalid input, staff member name must have at least one character! Try again.\n");
                Console.Write($"\nEnter name of Staff Member {index + 1}: ");
                staffName = Console.ReadLine();
            }

            return staffName;
        }

        public string RetrieveClassName(string position, string staffName)
        {
            Console.Write($"\nClass name that {position} {staffName} will teach?: ");
            string className = Console.ReadLine();

            while (className.Length == 0)
            {
                Console.WriteLine("Invalid input, class name must be at least one character! Try again.");
                Console.Write($"\nClass name that {position} {staffName} will teach?: ");
                className = Console.ReadLine();
            }

            return className;
        }

        public int RetrieveUniversityDepartmentTotal()
        {
            Console.Write("\nEnter the number of departments at this university: ");
            bool success = int.TryParse(Console.ReadLine(), out int departmentCount);

            while (!success || departmentCount <= 0)
            {
                Console.WriteLine("Invalid input, must be 1 department or greater! Try again.\n");
                Console.Write("\nEnter the number of departments at this university: ");
                success = int.TryParse(Console.ReadLine(), out departmentCount);
            }

            return departmentCount;
        }

        public int RetrieveDepartmentStaffCount(int index)
        {
            Console.Write($"\nEnter the total number of staff in Department #{index + 1}: ");
            bool success = int.TryParse(Console.ReadLine(), out int staffCount);

            while (!success || staffCount <= 0)
            {
                Console.WriteLine("Invalid input, must be 1 staff member or greater! Try again.\n");
                Console.Write($"\nEnter the total number of staff in Department #{index + 1}: ");
                success = int.TryParse(Console.ReadLine(), out staffCount);
            }

            return staffCount;
        }

        public int RetrieveStaffPosition(string staffName)
        {
            Console.WriteLine("\nStaff Position Choices");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("[1] Dean");
            Console.WriteLine("[2] Administrator");
            Console.WriteLine("[3] Professor");
            Console.WriteLine("[4] Researcher\n");

            Console.Write($"\nEnter the staff position digit for {staffName}: ");
            bool success = int.TryParse(Console.ReadLine(), out int staffPosition);

            while (!success || staffPosition > 4 || staffPosition < 1)
            {
                Console.WriteLine("Invalid input, incorrect staff position digit! Try again.");
                Console.Write($"\nEnter the staff position digit for {staffName}: ");
                success = int.TryParse(Console.ReadLine(), out staffPosition);
            }

            return staffPosition;
        }

        public int RetrieveResearchSpeciality(string staffName)
        {
            Console.WriteLine("\nResearch Speciality Choices");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("[1] Machine Learning");
            Console.WriteLine("[2] Calculus");
            Console.WriteLine("[3] Trigonometry");
            Console.WriteLine("[4] Computer Vision");
            Console.WriteLine("[5] Literature");
            Console.WriteLine("[6] Topology\n");

            Console.Write($"\nResearch Speciality digit that Researcher {staffName} will study?: ");
            bool success = int.TryParse(Console.ReadLine(), out int researchSpeciality);

            while (!success || researchSpeciality < 1 || researchSpeciality > 6)
            {
                Console.WriteLine("Invalid input, Research Speciality digit must be greater than 0! Try again.");
                Console.Write($"\nResearch Speciality digit that Researcher {staffName} will study?: ");
                success = int.TryParse(Console.ReadLine(), out researchSpeciality);
            }

            return researchSpeciality;
        }

        public double RetrieveSalaryAmount(string position, string staffName)
        {
            Console.Write($"\nSalary amount for {position} {staffName}? [#] or [#.##]: ");
            bool success = Double.TryParse(Console.ReadLine(), out double salary);

            while (!success || salary <= 0)
            {
                Console.WriteLine("Invalid input, salary must be greater than 0! Try again.");
                Console.Write($"\nSalary amount for {position} {staffName}? [#] or [#.##]: ");
                success = Double.TryParse(Console.ReadLine(), out salary);
            }

            return salary;
        }

        public char RetrieveWillDeanTeach(string staffName)
        {
            Console.Write($"\nWill Dean {staffName} teach a class as well? (y/n): ");
            bool success = char.TryParse(Console.ReadLine(), out char willTeach);

            if (success)
            {
                willTeach = Char.ToLower(willTeach);
            }

            while (!success || (willTeach != 'y' && willTeach != 'n'))
            {
                Console.WriteLine("Invalid input, must be [y/Y] or [n/N]! Try again.\n");
                Console.Write($"\nWill Dean {staffName} teach a class as well? (y/n): ");
                success = char.TryParse(Console.ReadLine(), out willTeach);
            }

            return willTeach;
        }

        public char RetrieveContinueInput()
        {
            Console.Write("Would you like to create another university? (y/n): ");
            bool success = char.TryParse(Console.ReadLine(), out char runInput);

            if(success)
            {
                runInput = Char.ToLower(runInput);
            }

            while(!success || (runInput != 'y' && runInput != 'n'))
            {
                Console.WriteLine("Invalid input, must be [y/Y] or [n/N]! Try again.\n");
                Console.Write("Would you like to create another university? (y/n): ");
                success = char.TryParse(Console.ReadLine(), out runInput);
            }

            return runInput;
        }
    }
}
