using System.ComponentModel.DataAnnotations;
using PawConnect.Domain.Entities; // for UserRole

namespace PawConnect.Api.API.Users.RequestObject
{
    public class RegisterUserRequest
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; }

        public UserRole Role { get; set; } = UserRole.User;
    }
}
