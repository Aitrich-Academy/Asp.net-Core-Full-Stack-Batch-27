using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface IPetCareServiceRepository
    {
        Task<PetCareService?> GetByIdAsync(int id);
        Task<IEnumerable<PetCareService>> GetAllAsync();
        Task<IEnumerable<PetCareService>> GetByShelterIdAsync(Guid shelterId);
        Task<IEnumerable<PetCareService>> GetByProviderIdAsync(Guid providerId);
        Task AddAsync(PetCareService service);
        Task UpdateAsync(PetCareService service);
        Task DeleteAsync(PetCareService service);
        Task SaveChangesAsync();
    }
}
