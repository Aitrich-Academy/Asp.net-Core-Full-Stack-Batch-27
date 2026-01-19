using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class FavoritePetService : IFavoritePetService
    {
        private readonly IFavoritePetRepository _repo;

        public FavoritePetService(IFavoritePetRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddAsync(Guid userId, int petId)
        {
            var exists = await _repo.GetAsync(userId, petId);
            if (exists != null) return true;

            var fav = new FavoritePet
            {
                UserId = userId,
                PetId = petId
            };

            await _repo.AddAsync(fav);
            return await _repo.SaveChangesAsync();
        }

        public async Task<bool> RemoveAsync(Guid userId, int petId)
        {
            var fav = await _repo.GetAsync(userId, petId);
            if (fav == null) return false;

            await _repo.RemoveAsync(fav);
            return await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<FavoritePet>> GetMyFavoritesAsync(Guid userId)
        {
            return await _repo.GetByUserAsync(userId);
        }
    }
}
