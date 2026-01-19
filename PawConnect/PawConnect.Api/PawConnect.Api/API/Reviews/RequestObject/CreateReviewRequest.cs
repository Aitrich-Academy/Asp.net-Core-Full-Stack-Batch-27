using System.ComponentModel.DataAnnotations;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Reviews.RequestObject
{
    public class CreateReviewRequest
    {
        [Required]
        public Guid TargetId { get; set; } // shelter or provider id

        [Required]
        public TargetType TargetType { get; set; } // enum: Shelter or Provider

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }
    }
}
