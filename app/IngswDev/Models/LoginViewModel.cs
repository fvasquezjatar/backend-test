using System.ComponentModel.DataAnnotations;

namespace IngswDev.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
