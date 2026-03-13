using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawConnect.Domain.Entities
{
    public class Shelter
    {
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Location { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        public Guid OwnerUserId { get; set; }

        [ForeignKey(nameof(OwnerUserId))]
        public User? OwnerUser { get; set; }

        public bool IsVerified { get; set; } = false;

        // Navigation
        public ICollection<PetCareService>? Services { get; set; }
    }
}
