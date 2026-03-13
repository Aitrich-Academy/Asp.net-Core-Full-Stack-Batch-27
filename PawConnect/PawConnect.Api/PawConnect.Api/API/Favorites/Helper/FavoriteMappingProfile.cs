using AutoMapper;
using PawConnect.Api.API.Favorites.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Favorites.Helper
{
    public class FavoriteMappingProfile : Profile
    {
        public FavoriteMappingProfile()
        {
            CreateMap<FavoritePet, FavoriteResponse>()
                .ForMember(d => d.PetName, opt => opt.MapFrom(s => s.Pet != null ? s.Pet.Name : string.Empty))
                .ForMember(d => d.PetImageUrl, opt => opt.MapFrom(s => s.Pet != null ? s.Pet.ImageUrl : null))
                .ForMember(d => d.PetStatus, opt => opt.MapFrom(s => s.Pet != null ? s.Pet.Status : PetStatus.Available));
        }
    }
}
