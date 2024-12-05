using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqloProject.Areas.Admin.ViewModels;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{

    private readonly AppDbContext _context;
    IWebHostEnvironment _webHostEnvironment;
    public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        //IEnumerable<Product> products = _context.Products.ToList();
        IEnumerable<Product> products = _context.Products.Include(s=> s.Category).ToList();
        return View(products);
    }

    public IActionResult Delete(int id)
    {
        Product? deletedProduct = _context.Products.Find(id);
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
            return View(product); 
        }

        if (!product.ImageUrl.Contains("image"))
        {
            ModelState.AddModelError("Image", "Only image format accepted");
            return View(product);   
        }

        string path = _webHostEnvironment.WebRootPath + @"\images\product\";
        string fileName = product.Image.FileName;
        using(FileStream fileStream = new FileStream(path + fileName, FileMode.Create))
        {
            product.Image.CopyTo(fileStream);
        }
        product.ImageUrl = fileName;


        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));


        //if (!ModelState.IsValid)
        //{
        //    return BadRequest("Something went wrong");
        //}
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
