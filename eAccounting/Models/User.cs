using System.ComponentModel.DataAnnotations;

namespace eAccounting.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters")]
        public string FullName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 100 characters")]
        public string Email { get; set; }
        [Required]
        [StringLength(200)] // hashed passwords are long
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Role must be 4–20 characters")]

        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;




    }
}
