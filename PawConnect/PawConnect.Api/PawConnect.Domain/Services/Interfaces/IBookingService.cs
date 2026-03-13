using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> CreateBookingAsync(Guid userId, int serviceId, DateTime date);
        Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId);
        Task<IEnumerable<Booking>> GetProviderBookingsAsync(Guid providerId);
        Task<bool> CancelBookingAsync(Guid bookingId, Guid userId, bool isAdmin = false);
    }
}
