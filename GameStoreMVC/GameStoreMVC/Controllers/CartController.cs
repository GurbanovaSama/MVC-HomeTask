using GameStoreMVC.DAL;
using GameStoreMVC.DTOs.BasketDTOs;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Newtonsoft.Json;

namespace GameStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BasketDto basket = GetBasket(); 
            return View(basket);
        }

        public IActionResult AddToBasket(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            Game? game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            };
            BasketDto basket = GetBasket();
            if(basket == null)
            {
                basket = new BasketDto();       
            }

            BasketItemDto? existingBasketItem =  basket.Items.FirstOrDefault(g => g.Id == game.Id);
            if(existingBasketItem == null)
            {
                BasketItemDto basketItemDto = new BasketItemDto()
                {
                    Id = game.Id,
                    Title = game.Title,
                    Price = game.Price,
                    ImagePath = game.ImageUrl,
                    Quantity = 1
                };
                basket.Items.Add(basketItemDto);
            }
            else
            {
                existingBasketItem.Quantity += 1;
            }
            var cookieBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", cookieBasket, cookieOptions);

            return RedirectToAction("Index", "Home");  
        }

        public BasketDto GetBasket()
        {
            var basket = Request.Cookies["Basket"];
            if (basket != null)
            {
               BasketDto existingBasket = JsonConvert.DeserializeObject<BasketDto>(basket);   
                return existingBasket;  
            }
            return null;  
        }   


        public IActionResult DeleteBasketItem(int id)
        {
            var basket = GetBasket();   
            if(basket.Items.Any(g => g.Id == id))
            {
                BasketItemDto deleteBasketItem = basket.Items.Find(g => g.Id == id);        
                basket.Items.Remove(deleteBasketItem);
                var cookieBasket = JsonConvert.SerializeObject(basket);
                var cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true
                };
                Response.Cookies.Append("Basket", cookieBasket, cookieOptions);

                return RedirectToAction("Index");
            }
            return BadRequest();
        }

    }
}
