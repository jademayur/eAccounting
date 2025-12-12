using eAccounting.DTOs;
using eAccounting.Models;
using eAccounting.Repositories;

namespace eAccounting.Services
{
    public class FinancialYearService: IFinancialYearService
    {
        private readonly IFinancialYearRepository _repo;

        public FinancialYearService(IFinancialYearRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<FinancialYearDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();

            return list.Select(fy => new FinancialYearDto
            {
                Id = fy.Id,
                CompanyId = fy.CompanyId,
                YearName = fy.YearName,
                StartDate = fy.StartDate,
                EndDate = fy.EndDate
            }).ToList();
        }

        public async Task<FinancialYearDto> GetByIdAsync(int id)
        {
            var fy = await _repo.GetByIdAsync(id);
            if (fy == null) return null;

            return new FinancialYearDto
            {
                Id = fy.Id,
                CompanyId = fy.CompanyId,
                YearName = fy.YearName,
                StartDate = fy.StartDate,
                EndDate = fy.EndDate
            };
        }

        public async Task<FinancialYearDto> CreateAsync(CreateFinancialYearDto dto)
        {
            var entity = new FinancialYear
            {
                CompanyId = dto.CompanyId,
                YearName = dto.YearName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            await _repo.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<FinancialYearDto> UpdateAsync(int id, CreateFinancialYearDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.CompanyId = dto.CompanyId;
            existing.YearName = dto.YearName;
            existing.StartDate = dto.StartDate;
            existing.EndDate = dto.EndDate;

            await _repo.UpdateAsync(existing);
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
