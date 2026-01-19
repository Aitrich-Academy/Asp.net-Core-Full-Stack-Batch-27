using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet?> GetByIdAsync(int id);
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<IEnumerable<Pet>> GetByOwnerIdAsync(Guid ownerId);
        Task AddAsync(Pet pet);
        Task UpdateAsync(Pet pet);
        Task DeleteAsync(Pet pet);
        Task SaveChangesAsync();
    }
}
