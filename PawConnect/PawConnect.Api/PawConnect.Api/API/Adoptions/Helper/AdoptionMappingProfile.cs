using AutoMapper;
using PawConnect.Api.API.Adoptions.RequestObject;
using PawConnect.Api.API.Adoptions.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Adoptions.Helper
{
    public class AdoptionMappingProfile : Profile
    {
        public AdoptionMappingProfile()
        {
            CreateMap<AdoptionRequest, AdoptionResponse>()
                .ForMember(d => d.PetName, opt => opt.MapFrom(s => s.Pet != null ? s.Pet.Name : string.Empty))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User != null ? s.User.FullName : string.Empty));
        }
    }
}
