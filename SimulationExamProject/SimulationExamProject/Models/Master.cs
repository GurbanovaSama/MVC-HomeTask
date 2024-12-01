using SimulationExamProject.Models.Base;

namespace SimulationExamProject.Models
{
    public class Master : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public int ExperienceYear { get; set; }
        public bool IsActive { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
