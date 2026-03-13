using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class SurrenderRequestRepository : ISurrenderRequestRepository
    {
        private readonly PawConnectDbContext _context;

        public SurrenderRequestRepository(PawConnectDbContext context)
        {
            _context = context;
        }

        public async Task<SurrenderRequest?> GetByIdAsync(Guid id)
            => await _context.SurrenderRequests.FirstOrDefaultAsync(s => s.Id == id);

        public async Task<IEnumerable<SurrenderRequest>> GetPendingAsync()
            => await _context.SurrenderRequests
                .Where(s => s.Status == SurrenderStatus.Pending)
                .ToListAsync();

        public async Task<IEnumerable<SurrenderRequest>> GetByUserIdAsync(Guid userId)
            => await _context.SurrenderRequests
                .Where(s => s.UserId == userId)
                .ToListAsync();

        public async Task AddAsync(SurrenderRequest request)
            => await _context.SurrenderRequests.AddAsync(request);

        public async Task UpdateAsync(SurrenderRequest request)
        {
            _context.SurrenderRequests.Update(request);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
