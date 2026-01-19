using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PawConnect.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // -------------------------
        //        PASSWORD HASHING
        // -------------------------
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool CheckPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        // -------------------------
        //        USER LOGIC
        // -------------------------

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            user.PasswordHash = HashPassword(password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task<User?> ValidateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return null;

            if (!CheckPassword(password, user.PasswordHash))
                return null;

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return;

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
