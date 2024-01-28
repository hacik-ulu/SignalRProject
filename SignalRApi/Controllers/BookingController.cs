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
            var values = _bookingService.TGetListAll();
            return Ok(values);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var deleteToBooking = _bookingService.TGetById(id);
            _bookingService.TDelete(deleteToBooking);
            return Ok("Rezervasyon başarıyla silindi!");
        }

		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			Booking booking = new Booking()
			{
				Mail = updateBookingDto.Mail,
				BookingID = updateBookingDto.BookingID,
				Name = updateBookingDto.Name,
				PersonCount = updateBookingDto.PersonCount,
				Phone = updateBookingDto.Phone,
				Date = updateBookingDto.Date
			};
			_bookingService.TUpdate(booking);
			return Ok("Rezervasyon Güncellendi");
		}

		[HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
