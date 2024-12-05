using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UniqloProject.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public string Price { get; set; }
    [AllowNull]
    public string ImageUrl { get; set; }    
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [NotMapped]
    public IFormFile Image { get; set; }
}
