using AutoMapper;
using PawConnect.Api.API.Admin.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Admin.Helper
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<User, AdminUserResponse>();
        }
    }
}
