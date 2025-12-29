using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Login.DTOs;

namespace Domain.Services.Login.Interfaces
{
    public interface ILoginRequestService
    {
        JobSeekerLoginDto Login(string email, string password);
    }
}
