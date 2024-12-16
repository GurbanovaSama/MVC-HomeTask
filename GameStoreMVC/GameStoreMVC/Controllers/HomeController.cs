using GameStoreMVC.DAL;
using GameStoreMVC.Models;
using GameStoreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GameStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Game> games = await _context.Games.ToListAsync();
            HomeVM homeVM = new HomeVM()
            {
                Games = games
            };
         

            return View(homeVM);
        }

        

    }
}
