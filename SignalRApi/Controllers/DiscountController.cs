using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService DiscountService, IMapper mapper)
        {
            _DiscountService = DiscountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_DiscountService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            //Yöntem 2 AutoMapper
            createDiscountDto.Status = false;
            _DiscountService.TAdd(_mapper.Map<Discount>(createDiscountDto));
            return Ok("Discount Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _DiscountService.TGetByID(id);
            _DiscountService.TDelete(value);
            return Ok("Discount Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            updateDiscountDto.Status = false;
            _DiscountService.TUpdate(_mapper.Map<Discount>(updateDiscountDto));
            return Ok("Discount Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _DiscountService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _DiscountService.TChangeStatusToTrue(id);
            return Ok("Ürün indirimi aktif hale getirildi");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _DiscountService.TChangeStatusToFalse(id);
            return Ok("Ürün indirimi pasif hale getirildi");
        }

        [HttpGet("[action]")]
        public IActionResult GetListByStatusTrue()
        {
            var values =_DiscountService.TGetListByStatusTrue();
            return Ok(values);
        }


    }
}
