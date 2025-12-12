using eAccounting.Models;

namespace eAccounting.Repositories
{
    public interface IFinancialYearRepository
    {
        Task<List<FinancialYear>> GetAllAsync();
        Task<FinancialYear> GetByIdAsync(int id);
        Task<FinancialYear> AddAsync(FinancialYear entity);
        Task<FinancialYear> UpdateAsync(FinancialYear entity);
        Task<bool> DeleteAsync(int id);
    }
}
