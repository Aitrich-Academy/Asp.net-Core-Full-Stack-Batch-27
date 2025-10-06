using HiringManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringManagementSystem.Interface
{
    public interface ILogin
    {
        bool Login(string email, string password);
        void Register(User user);
    }

}
