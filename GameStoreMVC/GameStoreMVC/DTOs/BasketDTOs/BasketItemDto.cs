namespace GameStoreMVC.DTOs.BasketDTOs
{
    public class BasketItemDto
    {
        public int Id { get; set; }     
        public decimal Price { get; set; }      
        public string Title { get; set; }
        public int Quantity { get; set; }   
        public string ImagePath { get; set; }   
    }
}
