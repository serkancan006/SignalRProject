﻿using AutoMapper;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntitiyLayer.Entities;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderDto>().ReverseMap();
        }

    }
}
