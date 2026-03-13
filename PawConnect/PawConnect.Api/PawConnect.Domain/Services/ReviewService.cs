using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> AddReviewAsync(Guid userId, Guid targetId, TargetType targetType, int rating, string? comment)
        {
            if (rating < 1 || rating > 5)
                throw new ArgumentException("Rating must be between 1 and 5.");

            var review = new Review
            {
                UserId = userId,
                TargetId = targetId,
                TargetType = targetType,
                Rating = rating,
                Comment = comment,
                CreatedAt = DateTime.UtcNow
            };

            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();

            return review;
        }

        public async Task<IEnumerable<Review>> GetByTargetAsync(Guid targetId, TargetType targetType)
        {
            return await _reviewRepository.GetByTargetAsync(targetId, targetType);
        }

        public async Task<double> GetAverageRatingAsync(Guid targetId, TargetType targetType)
        {
            var reviews = await _reviewRepository.GetByTargetAsync(targetId, targetType);
            if (!reviews.Any()) return 0;
            return reviews.Average(r => r.Rating);
        }

        public async Task<IEnumerable<Review>> GetByUserAsync(Guid userId)
        {
            return await _reviewRepository.GetByUserIdAsync(userId);
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, Guid userId, bool isAdmin = false)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null) return false;

            if (!isAdmin && review.UserId != userId)
                throw new UnauthorizedAccessException("You cannot delete this review.");

            await _reviewRepository.DeleteAsync(review);
            await _reviewRepository.SaveChangesAsync();
            return true;
        }
    }
}
