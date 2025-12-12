using eAccounting.DTOs;

namespace eAccounting.Services
{
    public interface IFinancialYearService
    {
        Task<List<FinancialYearDto>> GetAllAsync();
        Task<FinancialYearDto> GetByIdAsync(int id);
        Task<FinancialYearDto> CreateAsync(CreateFinancialYearDto dto);
        Task<FinancialYearDto> UpdateAsync(int id, CreateFinancialYearDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
