using HireMeNow.Exceptions;
using HireMeNow.Interface;
using HireMeNow.Models;

namespace HireMeNow.Services
{
    public class PublicService : IPublicService
    {
        public IUserRepository _userRepository;

        public PublicService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User loggedUser = new User();

        bool _islogged = false;

        public User LoginJobProvider(string email, string password)
        {
            try
            {
                loggedUser = _userRepository.login(email, password);
                
                if(loggedUser.Email != null)
                {
                    Console.WriteLine("Login Successful");

                    _islogged = true;
                    Console.WriteLine(loggedUser.FirstName);

                    return loggedUser;
                }
                else
                {
                    Console.WriteLine("Log in Filed");

                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new ServiceException("Technical Error Occured");
            }
        }

        public User Register(User user)
        {
            return _userRepository.register(user);
        }
    }
}
