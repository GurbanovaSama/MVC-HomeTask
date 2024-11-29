using MediClubMVC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MediClubMVC.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }   

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
