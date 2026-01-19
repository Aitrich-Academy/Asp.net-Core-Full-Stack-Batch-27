using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Services.Interfaces
{
    public interface IReviewService
    {
        Task<Review> AddReviewAsync(Guid userId, Guid targetId, TargetType targetType, int rating, string? comment);
        Task<IEnumerable<Review>> GetByTargetAsync(Guid targetId, TargetType targetType);
        Task<double> GetAverageRatingAsync(Guid targetId, TargetType targetType);
        Task<IEnumerable<Review>> GetByUserAsync(Guid userId);
        Task<Review?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id, Guid userId, bool isAdmin = false);
    }
}
