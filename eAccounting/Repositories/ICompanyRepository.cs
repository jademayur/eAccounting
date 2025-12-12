using eAccounting.Models;

namespace eAccounting.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> AddCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<bool> DeleteCompanyAsync(int id);

    }
}
