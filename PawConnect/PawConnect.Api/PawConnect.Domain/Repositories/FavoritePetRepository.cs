using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class FavoritePetRepository : IFavoritePetRepository
    {
        private readonly PawConnectDbContext _context;

        public FavoritePetRepository(PawConnectDbContext context)
        {
            _context = context;
        }

        public async Task<FavoritePet?> GetAsync(Guid userId, int petId)
        {
            return await _context.FavoritePets
                .FirstOrDefaultAsync(f => f.UserId == userId && f.PetId == petId);
        }

        public async Task<IEnumerable<FavoritePet>> GetByUserAsync(Guid userId)
        {
            return await _context.FavoritePets
                .Include(f => f.Pet)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(FavoritePet favorite)
        {
            await _context.FavoritePets.AddAsync(favorite);
        }

        public async Task RemoveAsync(FavoritePet favorite)
        {
            _context.FavoritePets.Remove(favorite);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
