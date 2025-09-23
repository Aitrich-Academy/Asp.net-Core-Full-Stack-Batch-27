using Admin_Job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Job.Interface
{
    public interface IUserRepository
    {
        List<User> getAll();
    }
}
