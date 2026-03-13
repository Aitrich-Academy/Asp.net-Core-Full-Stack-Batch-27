using AutoMapper;
using PawConnect.Api.API.Notifications.ResponseObject;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Notifications.Helper
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationResponse>();
        }
    }
}
