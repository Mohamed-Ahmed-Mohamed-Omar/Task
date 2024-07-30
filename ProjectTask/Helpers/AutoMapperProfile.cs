using AutoMapper;
using ProjectTask.Data.Entities;
using ProjectTask.Models;
using ProjectTask.Models.Department;
using ProjectTask.Models.SubDepartment;

namespace ProjectTask.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, CreateDepartment>().ReverseMap();

            CreateMap<Department, GetAllDepartments>().ReverseMap();

            CreateMap<Department, DepartmentVM>().ReverseMap();


            CreateMap<SubDepartment, CreateSubDepartment>().ReverseMap();

            CreateMap<SubDepartment, SubDepartmentVM>().ReverseMap();
        }
    }
}
