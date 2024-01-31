using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {

        private readonly ISocialMediaService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _SocialMediaService = SocialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_SocialMediaService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            //Yöntem 2 AutoMapper
            _SocialMediaService.TAdd(_mapper.Map<SocialMedia>(createSocialMediaDto));
            return Ok("SocialMedia Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetByID(id);
            _SocialMediaService.TDelete(value);
            return Ok("SocialMedia Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _SocialMediaService.TUpdate(_mapper.Map<SocialMedia>(updateSocialMediaDto));
            return Ok("SocialMedia Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetByID(id);
            return Ok(value);
        }
    }
}
