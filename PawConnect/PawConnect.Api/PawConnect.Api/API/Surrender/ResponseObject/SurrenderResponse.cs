using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Surrender.ResponseObject
{
    public class SurrenderResponse
    {
        public Guid Id { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public string? Reason { get; set; }
        public string? ImageUrl { get; set; }
        public SurrenderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // User info
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
    }
}
