using AutoMapper;
using ProjectTask.Data;
using ProjectTask.Data.Entities;
using ProjectTask.Models.SubDepartment;
using ProjectTask.Services.Interface;

namespace ProjectTask.Services.Repository
{
    public class SubDepartmentRepo : ISubDepartmentRepo
    {
        private readonly AppDbContext _context;
        private readonly IFileRepo _fileRepo;
        private readonly IMapper _mapper;

        public SubDepartmentRepo(AppDbContext context, IFileRepo fileRepo, IMapper mapper)
        {
            _context = context;
            _fileRepo = fileRepo;
            _mapper = mapper;
        }

        public string CreateSubDepartment(CreateSubDepartment model, string baseurl)
        {
            try
            {
                var data = _mapper.Map<SubDepartment>(model);

                var imageUrl = _fileRepo.UploadImage("Image", model.SubDepartment_Logo_Url);

                data.SubDepartment_Logo = baseurl + imageUrl;

                _context.SubDepartments.AddAsync(data);

                _context.SaveChanges();

                return "Done";
            }
            catch (Exception ex)
            {
                return "Faild";
            }
        }
    }
}
