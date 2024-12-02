using Microsoft.AspNetCore.Mvc;

namespace HospitalTask.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
