using HireMeNow.Models;

namespace HireMeNow.Interface
{
    public interface IUserService
    {
        User GetBiId(Guid guid);
    }
}
