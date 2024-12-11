using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
