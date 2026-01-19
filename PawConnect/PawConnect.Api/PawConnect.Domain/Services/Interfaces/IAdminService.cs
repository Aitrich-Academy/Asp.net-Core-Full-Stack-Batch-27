using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> VerifyUserAsync(Guid id);
        Task<bool> BlockUserAsync(Guid id);
        Task<bool> UnblockUserAsync(Guid id);
    }
}
