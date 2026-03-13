using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface IShelterRepository
    {
        Task<Shelter?> GetByIdAsync(Guid id);
        Task<IEnumerable<Shelter>> GetAllAsync();
        Task<IEnumerable<Shelter>> GetUnverifiedAsync();
        Task AddAsync(Shelter shelter);
        Task UpdateAsync(Shelter shelter);
        Task DeleteAsync(Shelter shelter);
        Task SaveChangesAsync();
    }
}
