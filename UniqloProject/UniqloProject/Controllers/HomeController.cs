using Microsoft.AspNetCore.Mvc;
using UniqloProject.DAL;

namespace UniqloProject.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
