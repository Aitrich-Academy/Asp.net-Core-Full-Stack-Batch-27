using PawConnect.Domain.Entities;

namespace PawConnect.Api.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user, out DateTime expiresAt);
    }
}
