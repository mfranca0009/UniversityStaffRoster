
namespace UniversityStaffRoster.Objects
{
    class Department
    {
        private string departmentName;
        private int staffTotal;
        private Staff[] staffMembers;

        public Department() { }

        public Department(int staffTotal) { this.staffTotal = staffTotal; }

        public void InitializeStaff()
        {
            staffMembers = new Staff[staffTotal];
        }

        public string Name { set => departmentName = value; get => departmentName; }

        public int TotalStaff { set => staffTotal = value; get => staffTotal; }

        public Staff[] Staff { get => staffMembers; }
    }
}
