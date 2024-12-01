using SimulationExamProject.Models.Base;

namespace SimulationExamProject.Models
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }   
        public string Description { get; set; }
        public bool IsActive { get; set; }  
        public ICollection<Master>? Masters { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }

    }
}
