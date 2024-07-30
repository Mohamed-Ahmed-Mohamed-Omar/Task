namespace ProjectTask.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Department_Name { get; set; }

        public string Department_Logo { get; set; }

        public ICollection<SubDepartment> SubDepartments { get; set; }
    }
}
