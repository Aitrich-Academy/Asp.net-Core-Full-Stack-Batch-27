using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuthUser.Interfaces
{
    public interface IAuthUserRepository
    {
        Task<Domain.Models.AuthUser> AddAuthUser(Domain.Models.AuthUser authUser);

        string CreateToken(Domain.Models.AuthUser user);
    }
}
