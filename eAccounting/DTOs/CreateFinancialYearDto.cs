using System.ComponentModel.DataAnnotations;

namespace eAccounting.DTOs
{
    public class CreateFinancialYearDto
    {
        [Required]
        public int CompanyId { get; set; }

        [Required, MaxLength(50)]
        public string YearName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
