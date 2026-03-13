using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Notification> SendAsync(Guid userId, string message);
        Task<IEnumerable<Notification>> GetForUserAsync(Guid userId);
        Task<bool> MarkAsReadAsync(int notificationId, Guid userId);
    }
}
