﻿using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
