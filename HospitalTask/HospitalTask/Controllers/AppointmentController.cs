using HospitalTask.DAL;
using HospitalTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalTask.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppDbContext _context;
        public AppointmentController(AppDbContext context)
        {
            _context = context; 
        }

        
        public IActionResult Index()
        {
            return View();
        }
   


        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (appointment.AppointmentDate <= DateTime.Now)
            {
                ModelState.AddModelError("", "Appointment date must be in the future.");
                return View(appointment);
            }



            var existingAppointment = await _context.Appointments
                .Where(a => a.DoctorId == appointment.DoctorId &&
                            a.AppointmentDate == appointment.AppointmentDate)
                .FirstOrDefaultAsync();

            if (existingAppointment != null)
            {
                ModelState.AddModelError("", "Doctor already has an appointment at this time.");
                return View(appointment);
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    } 
}