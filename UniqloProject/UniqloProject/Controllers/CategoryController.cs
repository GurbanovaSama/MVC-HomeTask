using Microsoft.AspNetCore.Mvc;

namespace UniqloProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
