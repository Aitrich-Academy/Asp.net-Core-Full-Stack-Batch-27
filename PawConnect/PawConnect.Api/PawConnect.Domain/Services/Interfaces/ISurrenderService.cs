using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface ISurrenderService
    {
        Task<SurrenderRequest> CreateRequestAsync(Guid userId, string petName, string? breed, int? age, string? reason, string? imageUrl);

        Task<IEnumerable<SurrenderRequest>> GetRequestsForUserAsync(Guid userId);

        Task<IEnumerable<SurrenderRequest>> GetPendingRequestsAsync();

        Task<SurrenderRequest?> UpdateStatusAsync(Guid requestId, SurrenderStatus status);
    }
}
