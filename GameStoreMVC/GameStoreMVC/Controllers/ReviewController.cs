using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
