namespace UniqloProject.Areas.Admin.ViewModels;

public class ProductCreateVM
{
    public string Name { get; set; }
    public string Price { get; set; }
    public IFormFile Image { get; set; }

}
