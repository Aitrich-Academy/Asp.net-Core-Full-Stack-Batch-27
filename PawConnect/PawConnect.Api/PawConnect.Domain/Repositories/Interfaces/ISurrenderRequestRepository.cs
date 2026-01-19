using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface ISurrenderRequestRepository
    {
        Task<SurrenderRequest?> GetByIdAsync(Guid id);
        Task<IEnumerable<SurrenderRequest>> GetPendingAsync();
        Task<IEnumerable<SurrenderRequest>> GetByUserIdAsync(Guid userId);
        Task AddAsync(SurrenderRequest request);
        Task UpdateAsync(SurrenderRequest request);
        Task SaveChangesAsync();
    }
}
