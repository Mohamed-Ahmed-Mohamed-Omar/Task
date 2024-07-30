namespace ProjectTask.Models.SubDepartment
{
    public class CreateSubDepartment
    {
        public string SubDepartment_Name { get; set; }

        public IFormFile SubDepartment_Logo_Url { get; set; }

        public int DepartmentId { get; set; }
    }
}
