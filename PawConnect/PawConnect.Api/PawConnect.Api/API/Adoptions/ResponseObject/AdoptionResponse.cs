using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Adoptions.ResponseObject
{
    public class AdoptionResponse
    {
        public Guid Id { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Message { get; set; }
        public AdoptionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
