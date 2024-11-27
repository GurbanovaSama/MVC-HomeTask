using System.ComponentModel.DataAnnotations;

namespace PurpleBuzzPr.DTOs.UserDTOs
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(2, ErrorMessage ="Name must be minumum 2 chars")]
        [MaxLength(55)]
        [Display(Prompt = "Fisrt Name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(65)]
        [Display(Prompt = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Required]
        [Length(2,35)]
        [Display(Prompt = "Username")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
        [Display(Prompt = "Repeat Password")]
        [DataType(DataType.Password), Compare(nameof(Password),ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
           
    }
}
