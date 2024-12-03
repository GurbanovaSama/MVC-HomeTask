using System.ComponentModel.DataAnnotations;

namespace SimulationExamProject.DTOs.UserDTOs
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be minimum 2 chars")]
        [MaxLength(55)]
        [Display(Prompt = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [MinLength (2)]
        [MaxLength(65)]
        [Display(Prompt = "LastName")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Required]
        [Length(3,30)]
        [Display(Prompt = "Username")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        [Display(Prompt = "Repeat Password")]
        public string ConfirmPassword { get; set; }

    }
}
