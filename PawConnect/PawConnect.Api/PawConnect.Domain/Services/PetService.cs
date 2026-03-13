using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            return await _petRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await _petRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Pet>> GetByOwnerIdAsync(Guid ownerId)
        {
            return await _petRepository.GetByOwnerIdAsync(ownerId);
        }

        public async Task<Pet> AddPetAsync(Pet pet)
        {
            await _petRepository.AddAsync(pet);
            await _petRepository.SaveChangesAsync();
            return pet;
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            await _petRepository.UpdateAsync(pet);
            await _petRepository.SaveChangesAsync();
        }

        public async Task DeletePetAsync(int petId)
        {
            var pet = await _petRepository.GetByIdAsync(petId);
            if (pet == null)
                return;

            await _petRepository.DeleteAsync(pet);
            await _petRepository.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int petId, PetStatus status)
        {
            var pet = await _petRepository.GetByIdAsync(petId);
            if (pet == null)
                throw new Exception("Pet not found");

            pet.Status = status;

            await _petRepository.UpdateAsync(pet);
            await _petRepository.SaveChangesAsync();
        }
    }
}
