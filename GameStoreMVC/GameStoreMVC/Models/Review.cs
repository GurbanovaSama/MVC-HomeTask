using GameStoreMVC.Models.Base;

namespace GameStoreMVC.Models
{
    public class Review : BaseAuditableEntity
    {
        public string Title { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }
 
    }
}
