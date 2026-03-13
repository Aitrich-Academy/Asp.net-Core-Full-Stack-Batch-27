using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IPetCareServiceRepository _serviceRepo;

        public BookingService(
            IBookingRepository bookingRepo,
            IPetCareServiceRepository serviceRepo)
        {
            _bookingRepo = bookingRepo;
            _serviceRepo = serviceRepo;
        }

        // CREATE BOOKING
        public async Task<Booking?> CreateBookingAsync(Guid userId, int serviceId, DateTime date)
        {
            var service = await _serviceRepo.GetByIdAsync(serviceId);
            if (service == null)
                return null;

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ServiceId = serviceId,
                BookingDate = date,
                Status = BookingStatus.Pending
            };

            await _bookingRepo.AddAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            return booking;
        }

        // GET my bookings
        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId)
        {
            return await _bookingRepo.GetByUserIdAsync(userId);
        }

        // Provider bookings
        public async Task<IEnumerable<Booking>> GetProviderBookingsAsync(Guid providerId)
        {
            return await _bookingRepo.GetByProviderIdAsync(providerId);
        }

        // CANCEL booking
        public async Task<bool> CancelBookingAsync(Guid bookingId, Guid userId, bool isAdmin = false)
        {
            var booking = await _bookingRepo.GetByIdAsync(bookingId);
            if (booking == null) return false;

            // user can cancel only their own booking unless Admin
            if (!isAdmin && booking.UserId != userId)
                throw new UnauthorizedAccessException("You cannot cancel this booking.");

            booking.Status = BookingStatus.Cancelled;

            await _bookingRepo.UpdateAsync(booking);
            return await _bookingRepo.SaveChangesAsync();
        }
    }
}
