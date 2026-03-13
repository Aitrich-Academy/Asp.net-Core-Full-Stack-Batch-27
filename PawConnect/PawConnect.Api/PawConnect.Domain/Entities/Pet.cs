using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawConnect.Domain.Entities
{
    public enum PetStatus
    {
        Available = 0,
        Pending = 1,
        Adopted = 2
    }

    public class Pet
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        [MaxLength(80)]
        public string? Breed { get; set; }

        public int? Age { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(300)]
        public string? ImageUrl { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public User? Owner { get; set; }

        public PetStatus Status { get; set; } = PetStatus.Available;

        // Navigation
        public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
        public ICollection<FavoritePet>? FavoritedBy { get; set; }
    }
}
