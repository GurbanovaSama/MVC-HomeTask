using Microsoft.AspNetCore.Mvc;

namespace SimulationExamProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
