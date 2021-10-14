using System;
using UniversityStaffRoster.Managers;

namespace UniversityStaffRoster.Objects
{
    class Runner
    {
        public Runner() { }

        public void NonInputDriver()
        {
            // Add 4 Departments to the University and initialize.
            var university = new University(4);
            university.InitializeDepartments();

            // Assign the University name
            university.Name = "Skaliose University";
            Console.WriteLine($"\n{university.Name} has been created!");

            for (int i = 0; i < university.TotalDepartments; i++)
            {
                // Add 4 staff member total to each department created, then initialize.
                university.Department[i] = new Department(4);
                university.Department[i].InitializeStaff();

                // Name the department based on index
                switch(i)
                {
                    case 0:
                        university.Department[i].Name = "Math";
                        break;
                    case 1:
                        university.Department[i].Name = "English";
                        break;
                    case 2:
                        university.Department[i].Name = "Science";
                        break;
                    case 3:
                        university.Department[i].Name = "Computer Science";
                        break;
                }
            }

            /* Math Department Staff Starts */
            university.Department[0].Staff[0] = new Researcher("Andy", 3000.00, ResearchSpeciality.Calculus, university.Department[0]);
            university.Department[0].Staff[1] = new Professor("Ralph", "Math", 1800.00, university.Department[0]);
            university.Department[0].Staff[2] = new Dean("Carmen", 5000.00, university.Department[0]);
            university.Department[0].Staff[3] = new Administrator("Sarah", 1100.00, university.Department[0]);
            /* Math Department Staff Ends */


            /* English Department Staff Starts */
            university.Department[1].Staff[0] = new Researcher("Sarah", 3000.00, ResearchSpeciality.Literature, university.Department[1]);
            university.Department[1].Staff[1] = new Professor("Robert", "English", 1800.00, university.Department[1]);
            university.Department[1].Staff[2] = new Dean("Lauren", 5000.00, university.Department[1]);
            university.Department[1].Staff[3] = new Administrator("George", 1100.00, university.Department[1]);
            /*English Department Staff Ends */

            /*Science Department Staff Starts */
            university.Department[2].Staff[0] = new Researcher("Larry", 3000.00, ResearchSpeciality.Biology, university.Department[2]);
            university.Department[2].Staff[1] = new Professor("Jessica", "Chemistry", 1800.00, university.Department[2]);
            university.Department[2].Staff[2] = new Dean("Isaac", 5000.00, "Anatomy", university.Department[2]);
            university.Department[2].Staff[3] = new Administrator("Veira", 1100.00, university.Department[2]);
            /*Science Department Staff Ends */

            /* Computer Science Department Staff Starts */
            university.Department[3].Staff[0] = new Researcher("Carl", 3000.00, ResearchSpeciality.ComputerVision, university.Department[3]);
            university.Department[3].Staff[1] = new Professor("Griffin", "Database Management", 1800.00, university.Department[3]);
            university.Department[3].Staff[2] = new Dean("Vanessa", 5000.00, university.Department[3]);
            university.Department[3].Staff[3] = new Administrator("Lola", 1100.00, university.Department[3]);
            /*Computer Science Department Staff Ends */

            // Displays university staff in its entirety
            university.DisplayStaffRoster();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void InputDriver()
        {
            InputManager inputManager = new InputManager();
            char runInput = 'y';

            while (runInput == 'y')
            {
                // Clear console from previous results, helps with readability when running the program again.
                Console.Clear();

                // Retrieve university name and total departments it will have
                string universityName = inputManager.RetrieveUniversityName();
                int departmentCount = inputManager.RetrieveUniversityDepartmentTotal();

                // Create the university and initialize its departments
                University university = new University(universityName, departmentCount);
                university.InitializeDepartments();
                Console.WriteLine($"\n{university.Name} has been created!");

                for (int i = 0; i < university.TotalDepartments; i++)
                {
                    // Retrieve the total number of staff in this department
                    int staffCount = inputManager.RetrieveDepartmentStaffCount(i);

                    // Create the department and initialize staff
                    university.Department[i] = new Department(staffCount);
                    university.Department[i].InitializeStaff();

                    // Retrieve the department name
                    university.Department[i].Name = inputManager.RetrieveDepartmentName(i);

                    for (int j = 0; j < university.Department[i].TotalStaff; j++)
                    {
                        // Retrieve the staff member's name and position they will hold
                        string staffName = inputManager.RetrieveStaffMemberName(j);
                        int staffPosition = inputManager.RetrieveStaffPosition(staffName);

                        switch (staffPosition)
                        {
                            case 1:   // Dean
                                {
                                    // Retrieve the Dean's salary, and determine if this Dean will also teach
                                    double salary = inputManager.RetrieveSalaryAmount("Dean", staffName);
                                    char willTeach = inputManager.RetrieveWillDeanTeach(staffName);

                                    // Create a new Dean based on the values given
                                    if (willTeach == 'y')
                                    {
                                        string className = inputManager.RetrieveClassName("Dean", staffName);
                                        university.Department[i].Staff[j] = new Dean(staffName, salary, className, university.Department[i]);
                                    }
                                    else
                                    {
                                        university.Department[i].Staff[j] = new Dean(staffName, salary, "None", university.Department[i]);
                                    }
                                    break;
                                }
                            case 2:   // Administrator
                                {
                                    // Retrieve Administrator's salary and create a new administrator with the values given.
                                    double salary = inputManager.RetrieveSalaryAmount("Administrator", staffName);
                                    university.Department[i].Staff[j] = new Administrator(staffName, salary, university.Department[i]);
                                    break;
                                }
                            case 3:  // Professor
                                {
                                    // Retrieve the Professor's salary and class that they will be teaching.
                                    double salary = inputManager.RetrieveSalaryAmount("Professor", staffName);
                                    string className = inputManager.RetrieveClassName("Professor", staffName);

                                    // Create a new Professor with the values given.
                                    university.Department[i].Staff[j] = new Professor(staffName, className, salary, university.Department[i]);
                                    break;
                                }
                            case 4:  // Researcher
                                {
                                    // Retrieve the Researcher's salary and research speciality
                                    double salary = inputManager.RetrieveSalaryAmount("Researcher", staffName);
                                    int researchSpeciality = inputManager.RetrieveResearchSpeciality(staffName);

                                    // Create a new Researcher with the values given.
                                    switch (researchSpeciality)
                                    {
                                        case 1:  // Machine Learning
                                            {
                                                university.Department[i].Staff[j] = new Researcher(staffName, salary, ResearchSpeciality.MachineLearning, university.Department[i]);
                                                break;
                                            }
                                        case 2:  // Calculus
                                            {
                                                university.Department[i].Staff[j] = new Researcher(staffName, salary, ResearchSpeciality.Calculus, university.Department[i]);
                                                break;
                                            }
                                        case 3:  // Trigonometry
                                            {
                                                university.Department[i].Staff[j] = new Researcher(staffName, salary, ResearchSpeciality.Trigonometry, university.Department[i]);
                                                break;
                                            }
                                        case 4:  // Computer Vision
                                            {
                                                university.Department[i].Staff[j] = new Researcher(staffName, salary, ResearchSpeciality.ComputerVision, university.Department[i]);
                                                break;
                                            }
                                        case 5: // Literature
                                            {
                                                university.Department[i].Staff[j] = new Researcher(staffName, salary, ResearchSpeciality.Literature, university.Department[i]);
                                                break;
                                            }
                                        case 6: // Topology
                                            {
                                                university.Department[i].Staff[j] = new Researcher(staffName, salary, ResearchSpeciality.Topology, university.Department[i]);
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }

                        // Display confirmation of staff member being added to the department
                        Console.WriteLine($"\n{university.Department[i].Staff[j].Name} has now been added to Department {university.Department[i].Name}!");
                    }

                    // Display confirmation of the department being added with the total staff members within it.
                    Console.WriteLine($"\nDepartment {university.Department[i].Name} has been created with {university.Department[i].TotalStaff} staff members!");
                }

                // Displays university staff in its entirety
                university.DisplayStaffRoster();

                // Retrieve whether the user wants to use the program again or exit.
                runInput = inputManager.RetrieveContinueInput();
            }
        }
    }
}
