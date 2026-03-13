using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class AdoptionRequestRepository : IAdoptionRequestRepository
    {
        private readonly PawConnectDbContext _context;

        public AdoptionRequestRepository(PawConnectDbContext context)
        {
            _context = context;
        }

        public async Task<AdoptionRequest?> GetByIdAsync(Guid id)
            => await _context.AdoptionRequests
                .Include(a => a.User)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<AdoptionRequest>> GetByUserIdAsync(Guid userId)
            => await _context.AdoptionRequests
                .Include(a => a.Pet)
                .Where(a => a.UserId == userId)
                .ToListAsync();

        public async Task<IEnumerable<AdoptionRequest>> GetByPetIdAsync(int petId)
            => await _context.AdoptionRequests
                .Include(a => a.User)
                .Where(a => a.PetId == petId)
                .ToListAsync();

        public async Task AddAsync(AdoptionRequest request)
            => await _context.AdoptionRequests.AddAsync(request);

        public async Task UpdateAsync(AdoptionRequest request)
        {
            _context.AdoptionRequests.Update(request);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
