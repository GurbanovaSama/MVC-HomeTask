using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulationExamProject.DAL;
using SimulationExamProject.Models;

namespace SimulationExamProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
          IEnumerable<Order> orders =  _context.Orders.ToList();
            return View(orders);
        }


        public IActionResult Delete(int id)
        {
            Order? deletedOrder = _context.Orders.Find(id);
            if(deletedOrder == null)
            {
                return NotFound();  
            }
            else
            {
                _context.Orders.Remove(deletedOrder);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            else
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            Order? order = _context.Orders.Find(Id);
            if (order is null)
            {
                return NotFound("No such order");
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult Update(Order order)
        {
            Order? updatedOrder = _context.Orders.AsNoTracking().FirstOrDefault(x => x.Id == order.Id);
            if (updatedOrder is null)
            {
                return NotFound("No such order");
            }

            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




    }
}
