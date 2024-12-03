using Microsoft.AspNetCore.Mvc;

namespace UniqloProject.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
