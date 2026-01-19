using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawConnect.Domain.Entities
{
    public enum BookingStatus
    {
        Pending = 0,
        Confirmed = 1,
        Cancelled = 2
    }

    public class Booking
    {
        public Guid Id { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public PetCareService? Service { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public DateTime BookingDate { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}
