using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepo;

        public AdminService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _adminRepo.GetAllUsersAsync();
        }

        public async Task<bool> VerifyUserAsync(Guid id)
        {
            var user = await _adminRepo.GetUserByIdAsync(id);
            if (user == null) return false;

            user.IsVerified = true;

            await _adminRepo.UpdateAsync(user);
            return await _adminRepo.SaveChangesAsync();
        }

        public async Task<bool> BlockUserAsync(Guid id)
        {
            var user = await _adminRepo.GetUserByIdAsync(id);
            if (user == null) return false;

            user.IsBlocked = true;

            await _adminRepo.UpdateAsync(user);
            return await _adminRepo.SaveChangesAsync();
        }

        public async Task<bool> UnblockUserAsync(Guid id)
        {
            var user = await _adminRepo.GetUserByIdAsync(id);
            if (user == null) return false;

            user.IsBlocked = false;

            await _adminRepo.UpdateAsync(user);
            return await _adminRepo.SaveChangesAsync();
        }
    }
}
