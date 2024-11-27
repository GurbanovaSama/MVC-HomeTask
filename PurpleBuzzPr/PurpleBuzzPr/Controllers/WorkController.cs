using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzPr.DAL;
using PurpleBuzzPr.Models;

namespace PurpleBuzzPr.Controllers;

public class WorkController : Controller
{
    private readonly AppDbContext _context;
    public WorkController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<Work> works = await _context.Works.ToListAsync();

        return View(works);
    }
 

  
    public IActionResult SingleWork(int id)
    {
        return View();
    }
  
}
