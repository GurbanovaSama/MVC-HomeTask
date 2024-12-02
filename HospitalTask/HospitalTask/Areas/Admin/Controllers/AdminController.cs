using HospitalTask.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HospitalTask.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var doctors = _context.Doctors.Where(d => d.IsActive).ToList();
            var patients = _context.Patients.Where(p => !p.IsDeleted).ToList();
            return View();
        }
    }
}
