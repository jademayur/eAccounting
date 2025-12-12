namespace eAccounting.DTOs
{
    public class FinancialYearDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string YearName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
