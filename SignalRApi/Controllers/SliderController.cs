﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntitiyLayer.Entities;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {

        private readonly ISliderService _SliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
            _SliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_SliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            //Yöntem 2 AutoMapper
            _SliderService.TAdd(_mapper.Map<Slider>(createSliderDto));
            return Ok("Slider Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _SliderService.TGetByID(id);
            _SliderService.TDelete(value);
            return Ok("Slider Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _SliderService.TUpdate(_mapper.Map<Slider>(updateSliderDto));
            return Ok("Slider Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _SliderService.TGetByID(id);
            return Ok(value);
        }
    }
}
