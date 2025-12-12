using System.ComponentModel.DataAnnotations;

namespace eAccounting.DTOs
{
    public class UpdateUserDto
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }   // optional

        [Required, StringLength(20, MinimumLength = 4)]
        public string Role { get; set; }

        public bool IsActive { get; set; }
    }
}
