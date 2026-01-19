using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface IFavoritePetRepository
    {
        Task<FavoritePet?> GetAsync(Guid userId, int petId);
        Task<IEnumerable<FavoritePet>> GetByUserAsync(Guid userId);
        Task AddAsync(FavoritePet favorite);
        Task RemoveAsync(FavoritePet favorite);
        Task<bool> SaveChangesAsync();
    }
}
