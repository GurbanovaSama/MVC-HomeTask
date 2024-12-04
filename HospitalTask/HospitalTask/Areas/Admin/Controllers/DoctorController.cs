using HospitalTask.Areas.Admin.DTOs.DoctorDTOs;
using HospitalTask.DAL;
using HospitalTask.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace HospitalTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
     
        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Doctor> doctors = await _context.Doctors.ToListAsync();
            //return View(doctors);
            var appDbContext = await _context.Doctors.Include(w=> w.HospitalDoctors).ThenInclude(w=> w.Hospital).ToListAsync();
            return View(appDbContext);
        }


        public IActionResult Delete(int id)
        {
            Doctor? deleteddoctor = _context.Doctors.Find(id);
            if (deleteddoctor == null)
            {
                return NotFound();
            }
            else
            {
                _context.Doctors.Remove(deleteddoctor);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }




        public IActionResult Create()
        {
            ViewBag.Hospitals = new SelectList(_context.Hospitals, "Id", "Name"); 

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(CreateDoctorDTO createDoctor)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View(createDoctor);
            }
            //createDoctor.Surname = createDoctor.Name + createDoctor.FinCode;


            Doctor newDoctor = new Doctor();
            newDoctor.Name = createDoctor.Name;
            newDoctor.Surname = createDoctor.Surname;
            newDoctor.FinCode = createDoctor.FinCode;
            newDoctor.PhoneNumber = createDoctor.PhoneNumber;
            newDoctor.Email = createDoctor.Email;
            newDoctor.IsActive = createDoctor.IsActive;
            _context.Doctors.Add(newDoctor);

            foreach(int hospitalId in createDoctor.HospitalIds)
            {
                if(!_context.Hospitals.Any(e => e.Id == hospitalId))
                {
                    return NotFound();
                }
            }   


            foreach (int hospitalId in createDoctor.HospitalIds)
            {
                _context.HospitalDoctors.Add(new HospitalDoctor
                {
                    HospitalId= hospitalId,
                    Doctor = newDoctor
                });
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Doctor? doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(nameof(Create), doctor);
        }
        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            Doctor? updateddoctor = _context.Doctors.AsNoTracking().FirstOrDefault(x => x.Id == doctor.Id);
            if (doctor == null)
            {
                return NotFound();
            }
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return View(Index);
        }

    }

}
