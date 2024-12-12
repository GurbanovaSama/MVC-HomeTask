﻿using GameStoreMVC.Models.Base;

namespace GameStoreMVC.Models
{
    public class Game : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int GameId { get; set; } 
    }
}
