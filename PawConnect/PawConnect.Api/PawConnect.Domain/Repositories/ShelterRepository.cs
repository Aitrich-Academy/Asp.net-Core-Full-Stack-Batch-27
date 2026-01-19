using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly PawConnectDbContext _context;

        public ShelterRepository(PawConnectDbContext context)
        {
            _context = context;
        }

        public async Task<Shelter?> GetByIdAsync(Guid id)
            => await _context.Shelters
                .Include(s => s.OwnerUser)
                .Include(s => s.Services)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<IEnumerable<Shelter>> GetAllAsync()
            => await _context.Shelters
                .Include(s => s.OwnerUser)
                .Include(s => s.Services)
                .ToListAsync();

        public async Task<IEnumerable<Shelter>> GetUnverifiedAsync()
            => await _context.Shelters
                .Where(s => !s.IsVerified)
                .ToListAsync();

        public async Task AddAsync(Shelter shelter)
            => await _context.Shelters.AddAsync(shelter);

        public async Task UpdateAsync(Shelter shelter)
        {
            _context.Shelters.Update(shelter);
        }

        public async Task DeleteAsync(Shelter shelter)
        {
            _context.Shelters.Remove(shelter);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
