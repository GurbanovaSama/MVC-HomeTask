using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            Category? deletedCategory = _context.Categories.Find(id);
            if (deletedCategory == null) { return NotFound(); }
            else
            {
                _context.Categories.Remove(deletedCategory);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            Category? category = _context.Categories.Find(Id);
            if (category is null)
            {
                return NotFound("No such category");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            Category? updatedCategory = _context.Categories.FirstOrDefault(category => category.Id == category.Id);
            if (updatedCategory is null)
            {
                return NotFound("No such category");
            }

            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
