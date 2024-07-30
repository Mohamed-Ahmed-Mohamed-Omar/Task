using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTask.Data.Entities;
using ProjectTask.Models.SubDepartment;
using ProjectTask.Services.Interface;
using ProjectTask.Services.Repository;

namespace ProjectTask.Controllers
{
    public class SubDepartmentController : Controller
    {
        private readonly ISubDepartmentRepo _subdepartmentRepo;
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubDepartmentController(ISubDepartmentRepo subdepartmentRepo, IHttpContextAccessor httpContextAccessor, IDepartmentRepo departmentRepo)
        {
            _subdepartmentRepo = subdepartmentRepo;
            _httpContextAccessor = httpContextAccessor;
            _departmentRepo = departmentRepo;
        }

        // GET: SubDepartmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubDepartmentController/Create
        public IActionResult Create()
        {
            var data = _departmentRepo.GetAllDepartment();

            ViewBag.DepartmentList = new SelectList(data, "Id", "Department_Name");

            return View();
        }

        // POST: SubDepartmentController/Create
        [HttpPost]
        public IActionResult Create(CreateSubDepartment createSubDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var context = _httpContextAccessor.HttpContext.Request;

                    var baseurl = $"{context.Scheme}://{context.Host}";

                    _subdepartmentRepo.CreateSubDepartment(createSubDepartment, baseurl);

                    return RedirectToAction("Index", "Home");
                }

                var data =  _departmentRepo.GetAllDepartment();

                ViewBag.DepartmentList = new SelectList(data, "Id", "Department_Name");

                return View(createSubDepartment);

            }
            catch (Exception ex)
            {
                var data = _departmentRepo.GetAllDepartment();

                ViewBag.DepartmentList = new SelectList(data, "Id", "Department_Name");

                return View(createSubDepartment);
            }
        }
    }
}
