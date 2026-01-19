using System.ComponentModel.DataAnnotations;

namespace PawConnect.Api.API.Pets.RequestObject
{
    public class UpdatePetRequest
    {
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
    }
}
