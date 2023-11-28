using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;
using System.Net.Mail;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService,IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var bookingList = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(bookingList);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            _bookingService.TAdd(new Booking()
            {
                Name = createBookingDto.Name,
                Date= createBookingDto.Date,
                Mail= createBookingDto.Mail,
                PersonCount= createBookingDto.PersonCount,
                Phone= createBookingDto.Phone,
            });
            return Ok("Kategori Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var deleteToBooking = _bookingService.TGetById(id);
            _bookingService.TDelete(deleteToBooking);
            return Ok("Rezervasyon başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {            
            _bookingService.TUpdate(new Booking
            {
                Name= updateBookingDto.Name,
                Date= updateBookingDto.Date,
                Mail= updateBookingDto.Mail,
                PersonCount= updateBookingDto.PersonCount,
                Phone= updateBookingDto.Phone,
            });
            return Ok("Rezervasyon başarıyla güncellendi!");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var booking = _bookingService.TGetById(id);
            return Ok(booking);
        }
    }
}
