namespace HospitalTask.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HospitalDoctor> HospitalDoctors { get; set; }    
    }
}
