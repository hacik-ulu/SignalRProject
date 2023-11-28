using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimionalDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimionalList()
        {
            var testimionalList = _mapper.Map<List<ResultTestimionalDto>>(_testimonialService.TGetListAll());
            return Ok(testimionalList);
        }

        [HttpPost]
        public IActionResult CreateTestimional(CreateTestimionalDto createTestimionalDto)
        {
            _testimonialService.TAdd(new Testimional
            {
                Comment = createTestimionalDto.Comment,
                ImageUrl = createTestimionalDto.ImageUrl,
                Name = createTestimionalDto.Name,
                Status = true,
                Title = createTestimionalDto.Title,

            });
            return Ok("Müşteri Yorum Bilgisi başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteTestimional(int id)
        {
            var deleteToTestimional = _testimonialService.TGetById(id);
            _testimonialService.TDelete(deleteToTestimional);
            return Ok("Müşteri Yorum Bilgisi silindi!");
        }

        [HttpPut]
        public IActionResult UpdateTestimional(UpdateTestimionalDto updateTestimionalDto)
        {
            _testimonialService.TUpdate(new Testimional
            {
                TestimionalID = updateTestimionalDto.TestimionalID,
                Comment = updateTestimionalDto.Comment,
                ImageUrl = updateTestimionalDto.ImageUrl,
                Name = updateTestimionalDto.Name,
                Status = updateTestimionalDto.Status,
                Title = updateTestimionalDto.Title,
            });
            return Ok("Müşteri Yorum Bilgisi başarıyla güncellendi!");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimional(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok(testimonial);
        }
    }
}
