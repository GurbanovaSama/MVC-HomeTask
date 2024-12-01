using Microsoft.AspNetCore.Mvc;
using SimulationExamProject.DAL;
using SimulationExamProject.Models;
using SimulationExamProject.ViewModels.Home;

namespace SimulationExamProject.Controllers
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
            List<Master> masters = _context.Masters.ToList();
            List<Order> orders = _context.Orders.ToList();
            List<Service> services = _context.Services.ToList();



            HomeVM homeVM = new HomeVM()
            {
                services = services,
                masters = masters,
                orders = orders
            };

            return View(homeVM);
        }


      
    }
}
