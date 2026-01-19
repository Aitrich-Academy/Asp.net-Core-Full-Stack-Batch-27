using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetUserNotificationsAsync(Guid userId);
        Task<Notification?> GetByIdAsync(int id);
        Task AddAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task<bool> SaveChangesAsync();
    }
}
