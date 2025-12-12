using eAccounting.Data;
using eAccounting.Models;
using Microsoft.EntityFrameworkCore;


namespace eAccounting.Repositories
{
    public class FinancialYearRepository : IFinancialYearRepository
    {
        private readonly AppDbContext _context;

        public FinancialYearRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FinancialYear>> GetAllAsync()
        {
            return await _context.FinancialYears.ToListAsync();
        }

        public async Task<FinancialYear> GetByIdAsync(int id)
        {
            return await _context.FinancialYears.FindAsync(id);
        }

        public async Task<FinancialYear> AddAsync(FinancialYear entity)
        {
            _context.FinancialYears.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<FinancialYear> UpdateAsync(FinancialYear entity)
        {
            _context.FinancialYears.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var fy = await _context.FinancialYears.FindAsync(id);
            if (fy == null) return false;

            _context.FinancialYears.Remove(fy);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
