using Microsoft.AspNetCore.Mvc;

namespace SimulationExamProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
