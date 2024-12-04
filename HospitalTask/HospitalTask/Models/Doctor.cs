namespace HospitalTask.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FinCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username => Name + FinCode;
        public bool IsActive { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<HospitalDoctor>? HospitalDoctors { get; set; }
    }
}
