﻿using HospitalTask.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HospitalTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context; 
        public HomeController(AppDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
