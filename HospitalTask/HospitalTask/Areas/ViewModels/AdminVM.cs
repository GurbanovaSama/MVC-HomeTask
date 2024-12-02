using HospitalTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalTask.Areas.ViewModels
{
    [Area("Admin")]
    public class AdminVM
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Appointment> UpcommingAppoinments { get; set; }
    }
}
