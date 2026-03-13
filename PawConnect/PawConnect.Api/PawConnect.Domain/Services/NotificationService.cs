using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepo;

        public NotificationService(INotificationRepository notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }

        public async Task<Notification> SendAsync(Guid userId, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            await _notificationRepo.AddAsync(notification);
            await _notificationRepo.SaveChangesAsync();

            return notification;
        }

        public async Task<IEnumerable<Notification>> GetForUserAsync(Guid userId)
        {
            return await _notificationRepo.GetUserNotificationsAsync(userId);
        }

        public async Task<bool> MarkAsReadAsync(int notificationId, Guid userId)
        {
            var notification = await _notificationRepo.GetByIdAsync(notificationId);

            if (notification == null || notification.UserId != userId)
                return false;

            notification.IsRead = true;

            await _notificationRepo.UpdateAsync(notification);
            return await _notificationRepo.SaveChangesAsync();
        }
    }
}
