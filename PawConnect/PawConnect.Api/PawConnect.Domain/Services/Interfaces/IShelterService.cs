using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IShelterService
    {
        Task<Shelter> CreateShelterAsync(Shelter shelter);

        Task<IEnumerable<Shelter>> GetAllAsync();

        Task<IEnumerable<Shelter>> GetUnverifiedAsync();

        Task<Shelter?> GetByIdAsync(Guid id);

        Task UpdateShelterAsync(Shelter shelter);

        Task VerifyShelterAsync(Guid shelterId);

        Task DeleteShelterAsync(Guid shelterId);
    }
}
