using System.ComponentModel.DataAnnotations;

namespace PawConnect.Api.API.Favorites.RequestObject
{
    public class AddFavoriteRequest
    {
        [Required]
        public int PetId { get; set; }
    }
}
