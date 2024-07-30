namespace ProjectTask.Models.Department
{
    public class DepartmentVM
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentLogo { get; set; }
        public List<SubDepartmentVM> SubDepartments { get; set; }
    }
}
