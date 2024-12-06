using SimulationExamProject.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimulationExamProject.Models
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }   
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [AllowNull]
        public string? MainImageUrl { get; set; }
        [NotMapped] 
        public IFormFile Image {  get; set; }



        public ICollection<Master>? Masters { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        //public List<IFormFile> AdditionalImages { get; internal set; }
    }
}
