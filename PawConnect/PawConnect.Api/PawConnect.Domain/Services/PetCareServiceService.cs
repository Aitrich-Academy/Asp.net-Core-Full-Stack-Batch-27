using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class PetCareServiceService : IPetCareServiceService
    {
        private readonly IPetCareServiceRepository _serviceRepo;

        public PetCareServiceService(IPetCareServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        public async Task<PetCareService> AddServiceAsync(PetCareService service)
        {
            await _serviceRepo.AddAsync(service);
            await _serviceRepo.SaveChangesAsync();
            return service;
        }

        public async Task UpdateServiceAsync(PetCareService service)
        {
            await _serviceRepo.UpdateAsync(service);
            await _serviceRepo.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var existing = await _serviceRepo.GetByIdAsync(id);
            if (existing == null)
                return;

            await _serviceRepo.DeleteAsync(existing);
            await _serviceRepo.SaveChangesAsync();
        }

        public async Task<PetCareService?> GetByIdAsync(int id)
        {
            return await _serviceRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PetCareService>> GetAllAsync()
        {
            return await _serviceRepo.GetAllAsync();
        }

        public async Task<IEnumerable<PetCareService>> GetByShelterAsync(Guid shelterId)
        {
            return await _serviceRepo.GetByShelterIdAsync(shelterId);
        }

        public async Task<IEnumerable<PetCareService>> GetByProviderAsync(Guid providerId)
        {
            return await _serviceRepo.GetByProviderIdAsync(providerId);
        }
    }
}
