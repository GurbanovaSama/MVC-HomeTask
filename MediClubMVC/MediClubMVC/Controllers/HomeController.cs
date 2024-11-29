using MediClubMVC.DAL;
using MediClubMVC.Models;
using MediClubMVC.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace MediClubMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }   

        public IActionResult Index()
        {
            var model = new HomeVM
            {
                Doctors = _context.Doctors.ToList(),    
                Services = _context.Services.ToList(),  
                Schedules = _context.Schedules.ToList(),    
            };

            return View(model);  
        }
     
    }
}
