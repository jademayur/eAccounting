using System.ComponentModel.DataAnnotations;

namespace eAccounting.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
