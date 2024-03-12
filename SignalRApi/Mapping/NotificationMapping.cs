using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntitiyLayer.Entities;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
        }
    }
}
