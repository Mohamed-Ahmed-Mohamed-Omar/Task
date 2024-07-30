using Microsoft.AspNetCore.Mvc;
using ProjectTask.Models.Department;
using ProjectTask.Services.Interface;

namespace ProjectTask.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentController(IDepartmentRepo departmentRepo, IHttpContextAccessor httpContextAccessor)
        {
            _departmentRepo = departmentRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = _departmentRepo.etAllDepartmentDetails();

            return View(departments);
        }

        // GET: DepartmentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        public IActionResult Create(CreateDepartment department)
        {
            if (ModelState.IsValid)
            {
                var context = _httpContextAccessor.HttpContext.Request;

                var baseurl = $"{context.Scheme}://{context.Host}";

                var result = _departmentRepo.CreateDepartment(department, baseurl);

                if (result == "Done")
                {
                    return RedirectToAction("Index", "Department");
                }
            }
            return View(department);
        }
    }
}
