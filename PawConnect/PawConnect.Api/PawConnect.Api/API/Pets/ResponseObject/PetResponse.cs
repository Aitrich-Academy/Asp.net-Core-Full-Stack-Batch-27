using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Pets.ResponseObject
{
    public class PetResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; } = string.Empty;

        public PetStatus Status { get; set; }
    }
}
