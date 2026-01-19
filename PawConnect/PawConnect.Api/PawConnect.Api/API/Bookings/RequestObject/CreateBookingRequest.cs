using System.ComponentModel.DataAnnotations;

namespace PawConnect.Api.API.Bookings.RequestObject
{
    public class CreateBookingRequest
    {
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
    }
}
