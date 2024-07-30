namespace ProjectTask.Data.Entities
{
    public class SubDepartment
    {
        public int Id { get; set; }

        public string SubDepartment_Name { get; set; }

        public string SubDepartment_Logo { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
