using UniversityStaffRoster.Objects;

namespace UniversityStaffRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner runner = new Runner();

            // Uncomment for a non-input driven test of this application
            //runner.NonInputDriver();

            // Input driven test of this application
            runner.InputDriver();
        }
    }
}
