using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class SurrenderService : ISurrenderService
    {
        private readonly ISurrenderRequestRepository _surrenderRepo;

        public SurrenderService(ISurrenderRequestRepository surrenderRepo)
        {
            _surrenderRepo = surrenderRepo;
        }

        public async Task<SurrenderRequest> CreateRequestAsync(Guid userId, string petName, string? breed, int? age, string? reason, string? imageUrl)
        {
            var request = new SurrenderRequest
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                PetName = petName,
                Breed = breed,
                Age = age,
                Reason = reason,
                ImageUrl = imageUrl,
                Status = SurrenderStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _surrenderRepo.AddAsync(request);
            await _surrenderRepo.SaveChangesAsync();

            return request;
        }

        public async Task<IEnumerable<SurrenderRequest>> GetRequestsForUserAsync(Guid userId)
        {
            return await _surrenderRepo.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<SurrenderRequest>> GetPendingRequestsAsync()
        {
            return await _surrenderRepo.GetPendingAsync();
        }

        public async Task<SurrenderRequest?> UpdateStatusAsync(Guid requestId, SurrenderStatus status)
        {
            var request = await _surrenderRepo.GetByIdAsync(requestId);
            if (request == null)
                return null;

            request.Status = status;

            await _surrenderRepo.UpdateAsync(request);
            await _surrenderRepo.SaveChangesAsync();

            return request;
        }
    }
}
