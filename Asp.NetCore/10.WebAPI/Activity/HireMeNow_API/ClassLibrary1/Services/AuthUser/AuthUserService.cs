using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.AuthUser.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Domain.Services.AuthUser
{
    public class AuthUserService:IAuthUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId()
        {
            var result = string.Empty;
            if(_contextAccessor.HttpContext != null)
            {
                result = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value.ToString();
            }

            return result;
        }
    }
}
