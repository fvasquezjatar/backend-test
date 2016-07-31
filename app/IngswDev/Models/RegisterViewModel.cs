using System.ComponentModel.DataAnnotations;

namespace IngswDev.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
