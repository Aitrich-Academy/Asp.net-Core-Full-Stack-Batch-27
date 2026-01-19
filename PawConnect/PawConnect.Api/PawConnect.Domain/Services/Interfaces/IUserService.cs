using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);

        Task<User> RegisterAsync(User user, string password);
        Task<User?> ValidateUserAsync(string email, string password);

        Task<IEnumerable<User>> GetAllAsync();

        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
