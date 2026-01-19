using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Reviews.ResponseObject
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Guid TargetId { get; set; }
        public TargetType TargetType { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
