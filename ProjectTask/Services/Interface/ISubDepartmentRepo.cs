using ProjectTask.Models.SubDepartment;

namespace ProjectTask.Services.Interface
{
    public interface ISubDepartmentRepo
    {
        string CreateSubDepartment(CreateSubDepartment model, string baseurl);
    }
}
