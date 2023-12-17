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
            var testimionalList = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(testimionalList);
        }

        [HttpPost]
        public IActionResult CreateTestimional(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial
            {
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = true,
                Title = createTestimonialDto.Title,

            });
            return Ok("Müşteri Yorum Bilgisi başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimional(int id)
        {
            var deleteToTestimional = _testimonialService.TGetById(id);
            _testimonialService.TDelete(deleteToTestimional);
            return Ok("Müşteri Yorum Bilgisi silindi!");
        }

        [HttpPut]
        public IActionResult UpdateTestimional(UpdateTestimonialDto updateTestimionalDto)
        {
            _testimonialService.TUpdate(new Testimonial
            {
                TestimonialID = updateTestimionalDto.TestimonialID,
                Comment = updateTestimionalDto.Comment,
                ImageUrl = updateTestimionalDto.ImageUrl,
                Name = updateTestimionalDto.Name,
                Status = updateTestimionalDto.Status,
                Title = updateTestimionalDto.Title,
            });
            return Ok("Müşteri Yorum Bilgisi başarıyla güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimional(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok(testimonial);
        }
    }
}
