using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawConnect.Domain.Entities
{
    public enum ServiceType
    {
        Grooming = 0,
        Boarding = 1,
        Vet = 2,
        Training = 3
    }

    public class PetCareService
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public ServiceType Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Guid? ProviderUserId { get; set; }
        public Guid? ShelterId { get; set; }

        [ForeignKey(nameof(ProviderUserId))]
        public User? ProviderUser { get; set; }

        [ForeignKey(nameof(ShelterId))]
        public Shelter? Shelter { get; set; }

        [MaxLength(200)]
        public string? Location { get; set; }
    }
}
