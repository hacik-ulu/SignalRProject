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

		public BookingController(IBookingService bookingService, IMapper mapper)
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
            Booking booking = new Booking()
            {
                Mail = createBookingDto.Mail,
                Date = createBookingDto.Date,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Description = createBookingDto.Description
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı");
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

		[HttpGet("BookingStatusApproved/{id}")]
		public IActionResult BookingStatusApproved(int id)
		{
			_bookingService.TBookingStatusApproved(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi!");
		}

		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.TBookingStatusCancelled(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi!");
		}

	}
}
