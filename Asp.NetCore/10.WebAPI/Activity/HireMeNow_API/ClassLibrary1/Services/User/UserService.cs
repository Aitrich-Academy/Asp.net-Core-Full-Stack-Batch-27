using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.User.Interface;
using Microsoft.AspNetCore.Http;

namespace Domain.Services.User
{
    public class UserService:IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public string GetUserId()
        {
            var result = string.Empty;
            if (httpContextAccessor.HttpContext != null)
            {
                result = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            }
            return result;
        }
    }
}
