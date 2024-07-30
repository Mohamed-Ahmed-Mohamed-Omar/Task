using ProjectTask.Models;
using ProjectTask.Models.Department;

namespace ProjectTask.Services.Interface
{
    public interface IDepartmentRepo
    {
        string CreateDepartment(CreateDepartment model, string baseurl);

        IQueryable<GetAllDepartments> GetAllDepartment();

        IEnumerable<DepartmentVM> etAllDepartmentDetails();
    }
}
