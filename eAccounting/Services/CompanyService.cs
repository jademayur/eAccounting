using eAccounting.DTOs;
using eAccounting.Models;
using eAccounting.Repositories;

namespace eAccounting.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;
        public CompanyService(ICompanyRepository companyRepository)
        {
            this._repo = companyRepository;
        }

        public async Task<List<CompanyDto>> GetAllAsync()
        {
            var companies = await _repo.GetAllCompaniesAsync();

            return companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Mobile = c.Mobile,
                Email = c.Email,
                GSTTIN = c.GSTTIN,
                PANNo = c.PANNo,
                Logo = c.Logo,
                StateCode = c.StateCode,
                RegistrationType = c.RegistrationType
            }).ToList();
        }

        public async Task<CompanyDto> GetByIdAsync(int id)
        {
            var c = await _repo.GetCompanyByIdAsync(id);
            if (c == null) return null;

            return new CompanyDto
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Mobile = c.Mobile,
                Email = c.Email,
                GSTTIN = c.GSTTIN,
                PANNo = c.PANNo,
                Logo = c.Logo,
                StateCode = c.StateCode,
                RegistrationType = c.RegistrationType
            };
        }

        public async Task<CompanyDto> CreateAsync(CreateCompanyDto dto)
        {
            var company = new Company
            {
                CompanyName = dto.CompanyName,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Mobile = dto.Mobile,
                Email = dto.Email,
                GSTTIN = dto.GSTTIN,
                PANNo = dto.PANNo,
                Logo = dto.Logo,
                StateCode = dto.StateCode,
                RegistrationType = dto.RegistrationType
            };

            await _repo.AddCompanyAsync(company);

            return await GetByIdAsync(company.Id);
        }

        public async Task<CompanyDto> UpdateAsync(int id, CreateCompanyDto dto)
        {
            var existing = await _repo.GetCompanyByIdAsync(id);
            if (existing == null) return null;

            existing.CompanyName = dto.CompanyName;
            existing.Address = dto.Address;
            existing.PhoneNumber = dto.PhoneNumber;
            existing.Mobile = dto.Mobile;
            existing.Email = dto.Email;
            existing.GSTTIN = dto.GSTTIN;
            existing.PANNo = dto.PANNo;
            existing.Logo = dto.Logo;
            existing.StateCode = dto.StateCode;
            existing.RegistrationType = dto.RegistrationType;

            await _repo.UpdateCompanyAsync(existing);

            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteCompanyAsync(id);
        }

    }
}
