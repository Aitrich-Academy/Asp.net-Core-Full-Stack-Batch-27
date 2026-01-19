using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class PetCareServiceRepository : IPetCareServiceRepository
    {
        private readonly PawConnectDbContext _context;

        public PetCareServiceRepository(PawConnectDbContext context)
        {
            _context = context;
        }

        public async Task<PetCareService?> GetByIdAsync(int id)
            => await _context.PetCareServices.FirstOrDefaultAsync(s => s.Id == id);

        public async Task<IEnumerable<PetCareService>> GetAllAsync()
            => await _context.PetCareServices.ToListAsync();

        public async Task<IEnumerable<PetCareService>> GetByShelterIdAsync(Guid shelterId)
            => await _context.PetCareServices
                .Where(s => s.ShelterId == shelterId)
                .ToListAsync();

        public async Task<IEnumerable<PetCareService>> GetByProviderIdAsync(Guid providerId)
            => await _context.PetCareServices
                .Where(s => s.ProviderUserId == providerId)
                .ToListAsync();

        public async Task AddAsync(PetCareService service)
            => await _context.PetCareServices.AddAsync(service);

        public async Task UpdateAsync(PetCareService service)
        {
            _context.PetCareServices.Update(service);
        }

        public async Task DeleteAsync(PetCareService service)
        {
            _context.PetCareServices.Remove(service);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
