using System.ComponentModel.DataAnnotations;

namespace eAccounting.Models
{
    public class Company
    {
        public int Id { get; set; }
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
        [MaxLength(30)]
        public string RegistrationType { get; set; }

    }
}
