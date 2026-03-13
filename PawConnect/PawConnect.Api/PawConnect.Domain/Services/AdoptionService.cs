using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IAdoptionRequestRepository _adoptionRepo;
        private readonly IPetRepository _petRepository;

        public AdoptionService(
            IAdoptionRequestRepository adoptionRepo,
            IPetRepository petRepository)
        {
            _adoptionRepo = adoptionRepo;
            _petRepository = petRepository;
        }

        public async Task<AdoptionRequest> CreateRequestAsync(Guid userId, int petId, string? message)
        {
            var pet = await _petRepository.GetByIdAsync(petId);
            if (pet == null)
                throw new Exception("Pet not found");

            if (pet.OwnerId == userId)
                throw new Exception("You cannot adopt your own pet.");

            if (pet.Status != PetStatus.Available)
                throw new Exception("Pet is not available for adoption.");

            // Avoid duplicate requests
            var existing = (await _adoptionRepo.GetByUserIdAsync(userId))
                            .FirstOrDefault(r => r.PetId == petId);

            if (existing != null)
                throw new Exception("You already submitted an adoption request for this pet.");

            var request = new AdoptionRequest
            {
                Id = Guid.NewGuid(),
                PetId = petId,
                UserId = userId,
                Message = message,
                Status = AdoptionStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _adoptionRepo.AddAsync(request);
            await _adoptionRepo.SaveChangesAsync();

            return request;
        }

        public async Task<IEnumerable<AdoptionRequest>> GetRequestsForUserAsync(Guid userId)
        {
            return await _adoptionRepo.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<AdoptionRequest>> GetRequestsForPetAsync(int petId)
        {
            return await _adoptionRepo.GetByPetIdAsync(petId);
        }

        public async Task<AdoptionRequest?> GetByIdAsync(Guid id)
        {
            return await _adoptionRepo.GetByIdAsync(id);
        }

        public async Task<AdoptionRequest?> UpdateStatusAsync(Guid requestId, AdoptionStatus status)
        {
            var request = await _adoptionRepo.GetByIdAsync(requestId);
            if (request == null)
                return null;

            request.Status = status;
            // OPTIONAL: update UpdatedAt if you add that field in the entity
            // request.UpdatedAt = DateTime.UtcNow;

            // If approved, mark pet as Adopted automatically (optional)
            if (status == AdoptionStatus.Approved)
            {
                var pet = await _petRepository.GetByIdAsync(request.PetId);
                if (pet != null)
                {
                    pet.Status = PetStatus.Adopted;
                    await _petRepository.UpdateAsync(pet);
                    // Do not call Save here; we'll call SaveChangesAsync below once to persist both
                }
            }

            await _adoptionRepo.UpdateAsync(request);
            // Single SaveChangesAsync will save both adoption update and pet update (same DbContext)
            await _adoptionRepo.SaveChangesAsync();

            return request;
        }
    }
}
