using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly PawConnectDbContext _db;

        public BookingRepository(PawConnectDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Booking booking)
        {
            await _db.Bookings.AddAsync(booking);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _db.Bookings.Update(booking);
            await Task.CompletedTask;
        }

        public async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _db.Bookings
                .Include(b => b.Service)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId)
        {
            return await _db.Bookings
                .Include(b => b.Service)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByProviderIdAsync(Guid providerId)
        {
            return await _db.Bookings
                .Include(b => b.Service)
                .Where(b => b.Service!.ProviderUserId == providerId)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
