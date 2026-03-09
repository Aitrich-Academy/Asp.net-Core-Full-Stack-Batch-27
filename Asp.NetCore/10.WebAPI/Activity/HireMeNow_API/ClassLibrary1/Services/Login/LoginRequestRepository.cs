using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services.Login.Interfaces;

namespace Domain.Services.Login
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        protected readonly AppDbContext _context;

        public LoginRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public Models.AuthUser GetUserByEmail(string email)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email);
            return user;
        }

        public Models.AuthUser GetUserByEmailPassword(string email, string password)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email && e.Password == password);
            return user;
        }
    }
}
