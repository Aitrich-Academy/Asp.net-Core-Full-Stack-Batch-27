namespace PawConnect.Api.API.Users.ResponseObject
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string Role { get; set; } = string.Empty;

        public bool IsVerified { get; set; }
    }
}
