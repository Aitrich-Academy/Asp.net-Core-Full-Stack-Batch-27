using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawConnect.Domain.Entities
{
    public enum AdoptionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }

    public class AdoptionRequest
    {
        public Guid Id { get; set; }

        [Required]
        public int PetId { get; set; }

        [ForeignKey(nameof(PetId))]
        public Pet? Pet { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [MaxLength(500)]
        public string? Message { get; set; }

        public AdoptionStatus Status { get; set; } = AdoptionStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
