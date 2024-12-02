using HospitalTask.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HospitalTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Dashboard : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
