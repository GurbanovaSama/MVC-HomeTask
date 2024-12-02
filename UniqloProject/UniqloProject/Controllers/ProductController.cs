using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            Product? deletedProduct= _context.Products.Find(id);
            if (deletedProduct == null) { return NotFound(); }
            else
            {
                _context.Products.Remove(deletedProduct);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));  
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            Product? product = _context.Products.Find(Id);
            if (product is null)
            {
                return NotFound("No such product");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            Product? updatedProduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == product.Id);
            if (updatedProduct is null)
            {
                return NotFound("No such product");
            }

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}
