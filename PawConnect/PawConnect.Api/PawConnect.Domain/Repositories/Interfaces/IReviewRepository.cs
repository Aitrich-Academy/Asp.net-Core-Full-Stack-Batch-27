using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task AddAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(Review review);
        Task<bool> SaveChangesAsync();

        Task<Review?> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetByTargetAsync(Guid targetId, TargetType targetType);
        Task<IEnumerable<Review>> GetByUserIdAsync(Guid userId);
    }
}
