using PurpleBuzzPr.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PurpleBuzzPr.Models
{
    public class Work : BaseAuditableEntity
    {
        
        public int Id { get; set; }
        [MinLength(3), DisallowNull]
        public string Title { get; set; }
        public string Description { get; set; }
        [AllowNull]
        public string MainImageUrl { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

    }
}
