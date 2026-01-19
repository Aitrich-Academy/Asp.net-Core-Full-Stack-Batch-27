using AutoMapper;
using PawConnect.Api.API.Pets.RequestObject;
using PawConnect.Api.API.Pets.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Pets.Helper
{
    public class PetMappingProfile : Profile
    {
        public PetMappingProfile()
        {
            // Create → Entity
            CreateMap<CreatePetRequest, Pet>();

            // Update → Entity (we update fields manually in service/controller)
            CreateMap<UpdatePetRequest, Pet>();

            // Entity → Response
            CreateMap<Pet, PetResponse>()
                .ForMember(dest => dest.OwnerName,
                    opt => opt.MapFrom(src => src.Owner != null ? src.Owner.FullName : string.Empty));
        }
    }
}
