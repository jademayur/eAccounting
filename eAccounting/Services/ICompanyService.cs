using eAccounting.DTOs;

namespace eAccounting.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllAsync();
        Task<CompanyDto> GetByIdAsync(int id);
        Task<CompanyDto> CreateAsync(CreateCompanyDto dto);
        Task<CompanyDto> UpdateAsync(int id, CreateCompanyDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
