using HireMeNow.Models;

namespace HireMeNow.Interface
{
    public interface IPublicService
    {
        public User LoginJobProvider(string email, string password);
        public User Register(User newJobSeeker);

    }
}
