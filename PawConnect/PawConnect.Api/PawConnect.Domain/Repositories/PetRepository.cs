using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PawConnectDbContext _context;

        public PetRepository(PawConnectDbContext context)
        {
            _context = context;
        }

        public async Task<Pet?> GetByIdAsync(int id)
            => await _context.Pets.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Pet>> GetAllAsync()
            => await _context.Pets.Include(p => p.Owner).ToListAsync();

        public async Task<IEnumerable<Pet>> GetByOwnerIdAsync(Guid ownerId)
            => await _context.Pets.Where(p => p.OwnerId == ownerId).ToListAsync();

        public async Task AddAsync(Pet pet)
            => await _context.Pets.AddAsync(pet);

        public async Task UpdateAsync(Pet pet)
        {
            _context.Pets.Update(pet);
        }

        public async Task DeleteAsync(Pet pet)
        {
            _context.Pets.Remove(pet);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
