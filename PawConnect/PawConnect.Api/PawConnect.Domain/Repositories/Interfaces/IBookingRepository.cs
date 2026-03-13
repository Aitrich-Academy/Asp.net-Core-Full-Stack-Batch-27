using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(Guid id);
        Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Booking>> GetByProviderIdAsync(Guid providerId);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task<bool> SaveChangesAsync();
    }
}
