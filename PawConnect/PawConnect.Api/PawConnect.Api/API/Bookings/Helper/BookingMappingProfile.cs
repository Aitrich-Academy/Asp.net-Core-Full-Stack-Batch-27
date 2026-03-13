using AutoMapper;
using PawConnect.Api.API.Bookings.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Bookings.Helper
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingResponse>()
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service!.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Service!.Price))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
