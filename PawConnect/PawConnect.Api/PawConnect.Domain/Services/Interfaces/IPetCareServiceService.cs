using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IPetCareServiceService
    {
        Task<PetCareService> AddServiceAsync(PetCareService service);

        Task UpdateServiceAsync(PetCareService service);

        Task DeleteServiceAsync(int id);

        Task<PetCareService?> GetByIdAsync(int id);

        Task<IEnumerable<PetCareService>> GetAllAsync();

        Task<IEnumerable<PetCareService>> GetByShelterAsync(Guid shelterId);

        Task<IEnumerable<PetCareService>> GetByProviderAsync(Guid providerId);
    }
}
