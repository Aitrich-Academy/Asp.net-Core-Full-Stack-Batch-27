using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Favorites.ResponseObject
{
    public class FavoriteResponse
    {
        public int Id { get; set; }             // favorite id
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string? PetImageUrl { get; set; }
        public Guid UserId { get; set; }        // who favorited
        public DateTime? CreatedAt { get; set; }
        public PetStatus PetStatus { get; set; }
    }
}
