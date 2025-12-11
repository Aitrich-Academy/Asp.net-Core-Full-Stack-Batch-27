using BlazorAuth.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BlazorAuth.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Registerr(string username, string password, string email)
        {
            if (await _db.Users.AnyAsync(u => u.Username == username)) return false;

            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Email = email
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Loginn(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || user.PasswordHash != HashPassword(password))
                return false;
            /*Runs the session-setting logic asynchronously to avoid blocking the main thread.*/
            await Task.Run(() =>
            {
                var context = _httpContextAccessor.HttpContext;
                if (context != null)
                {
                    context.Session.SetString("UserId", user.Id.ToString());
                    context.Session.SetString("Username", user.Username);
                    context.Session.SetString("Email", user.Email);
                }
            });

            return true;
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public string GetCurrentUser()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("Username");
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString("UserId"));
        }
        /*method HashPassword takes a plain-text password as input and returns
         a hashed version of it using SHA-256 encryption.*/
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();// Create a SHA-256 instance
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));// Convert password to byte array and hash it.
            return Convert.ToBase64String(bytes);// Convert the hashed bytes to a Base64 string and return.
        }
    }
    }

