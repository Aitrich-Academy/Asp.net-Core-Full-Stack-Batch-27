using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly PawConnectDbContext _db;

        public NotificationRepository(PawConnectDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(Guid userId)
        {
            return await _db.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<Notification?> GetByIdAsync(int id)
        {
            return await _db.Notifications
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddAsync(Notification notification)
        {
            await _db.Notifications.AddAsync(notification);
        }

        public async Task UpdateAsync(Notification notification)
        {
            _db.Notifications.Update(notification);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
