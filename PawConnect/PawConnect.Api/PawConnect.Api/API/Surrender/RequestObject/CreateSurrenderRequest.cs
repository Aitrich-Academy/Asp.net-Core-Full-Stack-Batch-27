using System.ComponentModel.DataAnnotations;

namespace PawConnect.Api.API.Surrender.RequestObject
{
    public class CreateSurrenderRequest
    {
        [Required]
        public string PetName { get; set; } = string.Empty;

        public string? Breed { get; set; }

        public int? Age { get; set; }

        public string? Reason { get; set; }

        public string? ImageUrl { get; set; }
    }
}
