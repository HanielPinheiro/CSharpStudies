using System.ComponentModel.DataAnnotations;

namespace Share.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "You must inser a valid e-mail.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [MinLength(6, ErrorMessage = "The field {0} must have, at least, {1} characters.")]
        public string Password { get; set; } = null!;
    }
}
