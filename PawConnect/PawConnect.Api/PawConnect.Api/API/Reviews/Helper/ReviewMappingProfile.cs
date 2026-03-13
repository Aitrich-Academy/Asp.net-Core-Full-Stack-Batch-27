using AutoMapper;
using PawConnect.Api.API.Reviews.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Reviews.Helper
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewResponse>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User != null ? s.User.FullName : string.Empty));
        }
    }
}
