using System.ComponentModel.DataAnnotations;

namespace eAccounting.DTOs
{
    public class CreateUserDto
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }   // We will hash this

        [Required, StringLength(20, MinimumLength = 4)]
        public string Role { get; set; }
    }
}
