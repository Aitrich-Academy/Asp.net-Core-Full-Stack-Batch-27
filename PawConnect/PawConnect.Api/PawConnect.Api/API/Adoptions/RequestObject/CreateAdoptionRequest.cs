using System.ComponentModel.DataAnnotations;

namespace PawConnect.Api.API.Adoptions.RequestObject
{
    public class CreateAdoptionRequest
    {
        [Required]
        public int PetId { get; set; }

        [MaxLength(1000)]
        public string? Message { get; set; }
    }
}
