using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IAdoptionService
    {
        Task<AdoptionRequest> CreateRequestAsync(Guid userId, int petId, string? message);

        Task<IEnumerable<AdoptionRequest>> GetRequestsForUserAsync(Guid userId);

        Task<IEnumerable<AdoptionRequest>> GetRequestsForPetAsync(int petId);

        Task<AdoptionRequest?> UpdateStatusAsync(Guid requestId, AdoptionStatus status);

        // NEW: get single request by id
        Task<AdoptionRequest?> GetByIdAsync(Guid id);
    }
}
