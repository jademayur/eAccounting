using eAccounting.DTOs;
using eAccounting.Helpers;
using eAccounting.Models;
using eAccounting.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace eAccounting.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();

            return list.Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt,
                LastUpdatedAt = u.LastUpdatedAt
            }).ToList();
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) return null;

            return new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt,
                LastUpdatedAt = u.LastUpdatedAt
            };
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            // Check duplicate email
            var existing = await _repo.GetByEmailAsync(dto.Email);
            if (existing != null)
                throw new Exception("Email already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = PasswordHelper.HashPassword(dto.Password),
                Role = dto.Role,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(user);
            return await GetByIdAsync(user.Id);
        }

        public async Task<UserDto> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Role = dto.Role;
            user.IsActive = dto.IsActive;

            if (!string.IsNullOrEmpty(dto.Password))
                user.PasswordHash = PasswordHelper.HashPassword(dto.Password);

            user.LastUpdatedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(user);

            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
