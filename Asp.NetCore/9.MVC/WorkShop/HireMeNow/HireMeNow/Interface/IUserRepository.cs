using HireMeNow.Models;

namespace HireMeNow.Interface
{
    public interface IUserRepository
    {
        User getLoggedUser();

        User login(string email, string password);
        User register(User user);
        User getById(Guid uid);

    }
}
