using AutoMapper;
using PawConnect.Api.API.Surrender.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Surrender.Helper
{
    public class SurrenderMappingProfile : Profile
    {
        public SurrenderMappingProfile()
        {
            CreateMap<SurrenderRequest, SurrenderResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User!.FullName));
        }
    }
}
