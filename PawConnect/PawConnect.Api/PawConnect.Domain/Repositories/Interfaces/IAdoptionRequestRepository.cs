using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface IAdoptionRequestRepository
    {
        Task<AdoptionRequest?> GetByIdAsync(Guid id);
        Task<IEnumerable<AdoptionRequest>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<AdoptionRequest>> GetByPetIdAsync(int petId);
        Task AddAsync(AdoptionRequest request);
        Task UpdateAsync(AdoptionRequest request);
        Task SaveChangesAsync();
    }
}
