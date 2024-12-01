using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SimulationExamProject.DAL;
using SimulationExamProject.Models;



namespace SimulationExamProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> services = await _context.Services.ToListAsync();

            return View(services);
        }

        public IActionResult Delete(int id)
        {
            Service? deletedService = _context.Services.Find(id);
            if (deletedService == null)
            {
                return NotFound();
            }
            else
            {
                _context.Services.Remove(deletedService);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            else
            {
                _context.Services.Add(service);
                _context.SaveChanges();
            }

         
            
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Update (int? Id)
        {
            Service? service = _context.Services.Find(Id);
            if(service is null)
            {
                return NotFound("No such service");
            }
            return View(service);  
        }

        [HttpPost]
        public IActionResult Update(Service service)
        {
            Service? updatedService = _context.Services.AsNoTracking().FirstOrDefault(x => x.Id == service.Id);
            if (updatedService is null)
            {
                return NotFound("No such service");
            }
           
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }   




    }
}
