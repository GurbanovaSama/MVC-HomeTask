using HospitalTask.Areas.ViewModels;
using HospitalTask.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HospitalTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var activeDoctors = _context.Doctors.Where(d => d.IsActive).ToList();
            var upcomingAppointments = _context.Appointments
                .Where(a => a.AppointmentDate > DateTime.Now)
                .OrderBy(a => a.AppointmentDate)
                .ToList();

            var viewModel = new AdminVM 
            {
                Doctors = activeDoctors,
                UpcommingAppoinments = upcomingAppointments
                
                 
            };



            return View(viewModel);
        }
    }
}
