namespace UniqloProject.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public string Price { get; set; }   
    public string ImageUrl { get; set; }    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
