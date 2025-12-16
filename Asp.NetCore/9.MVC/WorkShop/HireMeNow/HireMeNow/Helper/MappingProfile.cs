using AutoMapper;
using HireMeNow.Dto;
using HireMeNow.Models;

namespace HireMeNow.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobDto, Job>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<CompanyMemberDto, User>().ReverseMap();
        }
    }
}
