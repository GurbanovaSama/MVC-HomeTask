﻿using Microsoft.AspNetCore.Mvc;

namespace SimulationExamProject.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
