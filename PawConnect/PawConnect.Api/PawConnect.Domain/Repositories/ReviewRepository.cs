using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Repositories.Interfaces;

namespace PawConnect.Domain.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly PawConnectDbContext _db;

        public ReviewRepository(PawConnectDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Review review)
        {
            await _db.Reviews.AddAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            _db.Reviews.Update(review);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Review review)
        {
            _db.Reviews.Remove(review);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _db.Reviews
                .Include(r => r.User)     // include user so we can map User.FullName
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Review>> GetByTargetAsync(Guid targetId, TargetType targetType)
        {
            return await _db.Reviews
                .Include(r => r.User)
                .Where(r => r.TargetId == targetId && r.TargetType == targetType)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByUserIdAsync(Guid userId)
        {
            return await _db.Reviews
                .Include(r => r.User)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }
    }
}
