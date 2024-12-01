using SimulationExamProject.Models;

namespace SimulationExamProject.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Master> masters { get; set; }   
        public IEnumerable<Order> orders { get; set; }
        public IEnumerable<Service> services { get; set; }

    }
}
