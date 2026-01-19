using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IFavoritePetService
    {
        Task<bool> AddAsync(Guid userId, int petId);
        Task<bool> RemoveAsync(Guid userId, int petId);
        Task<IEnumerable<FavoritePet>> GetMyFavoritesAsync(Guid userId);
    }
}
