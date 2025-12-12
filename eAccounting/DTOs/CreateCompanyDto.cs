using System.ComponentModel.DataAnnotations;

namespace eAccounting.DTOs
{
    public class CreateCompanyDto
    {
        [Required, MaxLength(200)]
        public string CompanyName { get; set; }
        public string Address { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        [MaxLength(30)]
        public string Mobile { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string GSTTIN { get; set; }
        [MaxLength(10)]
        public string PANNo { get; set; }
        public string Logo { get; set; }
        public int StateCode { get; set; }
        public string RegistrationType { get; set; }
    }
}
