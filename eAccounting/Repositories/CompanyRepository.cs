using Microsoft.EntityFrameworkCore;
using eAccounting.Data;
using eAccounting.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace eAccounting.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly AppDbContext appDbContext;
        public CompanyRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await appDbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await appDbContext.Companies.FindAsync(id);
        }

        public async Task<Company> AddCompanyAsync(Company company)
        {
            appDbContext.Companies.Add(company);
            await appDbContext.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            appDbContext.Companies.Update(company);
            await appDbContext.SaveChangesAsync();
            return company;
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await appDbContext.Companies.FindAsync(id);
            if (company == null)
                return false;

            appDbContext.Companies.Remove(company);
            await appDbContext.SaveChangesAsync();
            return true;
        }

    }
}
