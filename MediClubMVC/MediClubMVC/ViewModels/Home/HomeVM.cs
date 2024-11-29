using MediClubMVC.Models;

namespace MediClubMVC.ViewModels.Home
{
    public class HomeVM
    {
        public List<Doctor> Doctors { get; set; }
        public List<Service> Services { get; set; } 
        public List<Schedule> Schedules { get; set; }   
    }
}
