using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using System.Net.Mail;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var response = _bookingService.TGetListAll();   
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Mail = createBookingDto.Mail,
                Date = createBookingDto.Date,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı!");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var response = _bookingService.TGetById(id);
            _bookingService.TDelete(response);
            return Ok("Rezervasyon başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new()
            {
                BookingID = updateBookingDto.BookingID,
                Mail = updateBookingDto.Mail,
                Date = updateBookingDto.Date,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount,
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon başarıyla güncellendi!");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var response = _bookingService.TGetById(id);
            return Ok(response);
        }
    }
}
