using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class ShelterService : IShelterService
    {
        private readonly IShelterRepository _shelterRepository;

        public ShelterService(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public async Task<Shelter> CreateShelterAsync(Shelter shelter)
        {
            await _shelterRepository.AddAsync(shelter);
            await _shelterRepository.SaveChangesAsync();

            return shelter;
        }

        public async Task<IEnumerable<Shelter>> GetAllAsync()
        {
            return await _shelterRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Shelter>> GetUnverifiedAsync()
        {
            return await _shelterRepository.GetUnverifiedAsync();
        }

        public async Task<Shelter?> GetByIdAsync(Guid id)
        {
            return await _shelterRepository.GetByIdAsync(id);
        }

        public async Task UpdateShelterAsync(Shelter shelter)
        {
            await _shelterRepository.UpdateAsync(shelter);
            await _shelterRepository.SaveChangesAsync();
        }

        public async Task VerifyShelterAsync(Guid shelterId)
        {
            var shelter = await _shelterRepository.GetByIdAsync(shelterId);
            if (shelter == null)
                throw new Exception("Shelter not found");

            shelter.IsVerified = true;

            await _shelterRepository.UpdateAsync(shelter);
            await _shelterRepository.SaveChangesAsync();
        }

        public async Task DeleteShelterAsync(Guid shelterId)
        {
            var shelter = await _shelterRepository.GetByIdAsync(shelterId);
            if (shelter == null)
                return;

            await _shelterRepository.DeleteAsync(shelter);
            await _shelterRepository.SaveChangesAsync();
        }
    }
}
