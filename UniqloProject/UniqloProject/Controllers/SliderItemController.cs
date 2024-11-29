using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Controllers
{
    public class SliderItemController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SliderItemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }   

        public IActionResult Index()
        {         
            IEnumerable<SliderItem> sliderItems = _appDbContext.SliderItems.ToList();
            return View(sliderItems);
        }
    }
}
