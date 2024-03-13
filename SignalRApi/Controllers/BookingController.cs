using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _BookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            //Yöntem 1
            Booking booking = new Booking()
            {
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Description = createBookingDto.Description
            };
            _BookingService.TAdd(booking);

            //Yöntem 2 AutoMapper

            return Ok("Booking Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _BookingService.TGetByID(id);
            _BookingService.TDelete(value);
            return Ok("Booking Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            };
            _BookingService.TUpdate(booking);
            return Ok("Booking Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _BookingService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _BookingService.TBookingStatusApproved(id);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult BookingStatusCancalled(int id)
        {
            _BookingService.TBookingStatusCancalled(id);
            return Ok();
        }
    }
}
