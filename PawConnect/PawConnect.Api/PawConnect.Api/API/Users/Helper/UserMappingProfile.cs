using AutoMapper;
using PawConnect.Api.API.Users.RequestObject;
using PawConnect.Api.API.Users.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Users.Helper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // Register → User entity
            CreateMap<RegisterUserRequest, User>();

            // User entity → UserResponse
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            // User entity → LoginResponse (used after login)
            CreateMap<User, LoginResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
