using Microsoft.AspNetCore.Mvc;

namespace SimulationExamProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
