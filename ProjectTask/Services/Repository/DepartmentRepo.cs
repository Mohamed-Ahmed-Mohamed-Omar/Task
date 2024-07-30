using AutoMapper;
using ProjectTask.Data;
using ProjectTask.Data.Entities;
using ProjectTask.Models;
using ProjectTask.Models.Department;
using ProjectTask.Services.Interface;

namespace ProjectTask.Services.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext _context;
        private readonly IFileRepo _fileRepo;
        private readonly IMapper _mapper;

        public DepartmentRepo(AppDbContext context, IFileRepo fileRepo, IMapper mapper)
        {
            _context = context;
            _fileRepo = fileRepo;
            _mapper = mapper;
        }

        public string CreateDepartment(CreateDepartment model, string baseurl)
        {
            try
            {
                var data = _mapper.Map<Department>(model);  

                var imageUrl = _fileRepo.UploadImage("Image", model.Department_Logo_Url);

                data.Department_Logo = baseurl + imageUrl;

                 _context.Departments.AddAsync(data);

                _context.SaveChanges();

                return "Done";
            }
            catch (Exception ex)
            {
                return "Faild";
            }
        }

        public IEnumerable<DepartmentVM> etAllDepartmentDetails()
        {
            var data= _context.Departments
            .Select(d => new DepartmentVM
            {
                DepartmentId = d.Id,
                DepartmentName = d.Department_Name,
                DepartmentLogo = d.Department_Logo,
                SubDepartments = d.SubDepartments.Select(sd => new SubDepartmentVM
                {
                    SubDepartmentId = sd.Id,
                    SubDepartmentName = sd.SubDepartment_Name,
                    SubDepartmentLogo = sd.SubDepartment_Logo
                }).ToList()
            }).ToList();

            return data;
        }

        public IQueryable<GetAllDepartments> GetAllDepartment()
        {
            var data = _context.Departments.Select(x => new GetAllDepartments
            {
                Id = x.Id,
                Department_Name = x.Department_Name
            });

            return data;
        }
    }
}
