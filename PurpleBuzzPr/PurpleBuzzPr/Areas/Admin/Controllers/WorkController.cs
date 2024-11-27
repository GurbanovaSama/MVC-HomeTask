using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzPr.DAL;
using PurpleBuzzPr.Models;

namespace PurpleBuzzPr.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;
        public WorkController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           IEnumerable<Work> works =await _context.Works.ToListAsync();
            return View(works);
        }

      
        public IActionResult Delete(int Id)
        {
            Work? deletedWork = _context.Works.Find(Id);
            if (deletedWork != null)
            {
                return NotFound();  
            }
            else
            {
                _context.Works.Remove(deletedWork);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Work work)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }

                _context.Works.Add(work);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            Work? work = _context.Works.Find(Id);
            if(work is  null)
            {
                return NotFound("No such work");
            }
            return View(work);  
        }

        [HttpPost]
        public IActionResult Update(Work work)
        {
            Work? updatedWork = _context.Works.AsNoTracking().FirstOrDefault(x => x.Id == work.Id);
            if (updatedWork is null)
            {
                return NotFound("No such work");
            }
       
            _context.Works.Update(work);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
