using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly PawConnectDbContext _db;

        public AdminRepository(PawConnectDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
