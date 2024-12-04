using HospitalTask.Models;

namespace HospitalTask.Areas.Admin.DTOs.DoctorDTOs
{
    public class CreateDoctorDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FinCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username => Name + FinCode;
        public bool IsActive { get; set; }
        public List<int> HospitalIds { get; set; }
    }
}
