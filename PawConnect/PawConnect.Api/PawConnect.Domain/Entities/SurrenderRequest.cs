using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawConnect.Domain.Entities
{
    public enum SurrenderStatus
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2
    }

    public class SurrenderRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required, MaxLength(80)]
        public string PetName { get; set; } = string.Empty;

        [MaxLength(80)]
        public string? Breed { get; set; }

        public int? Age { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }

        [MaxLength(300)]
        public string? ImageUrl { get; set; }

        public SurrenderStatus Status { get; set; } = SurrenderStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
