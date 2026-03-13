using System.ComponentModel.DataAnnotations;


namespace PawConnect.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; }

        public UserRole Role { get; set; } = UserRole.User;

        public bool IsVerified { get; set; } = false;

        public bool IsBlocked { get; set; } = false; 

        // Navigation
        public ICollection<Pet>? Pets { get; set; }
        public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
    }
}
