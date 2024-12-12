using GameStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreMVC.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Game> Games { get; set; }   
    }
}
