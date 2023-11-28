using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        // Business katmanlı ile iletişim kuracak
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var aboutList = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(aboutList);
        }

        // Dto uygulama katmanları arasında veriyi transfer etmek için kullanılır.
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutService.TAdd(new About()
            {
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
                Title = createAboutDto.Title,
            });
            return Ok("Hakkımda başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var deleteToAbout = _aboutService.TGetById(id);
            _aboutService.TDelete(deleteToAbout);
            return Ok("Hakkımda başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            _aboutService.TUpdate(new About()
            {
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,
                Title = updateAboutDto.Title,
            });
            return Ok("Hakkımda başarıyla güncellendi!");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var about = _aboutService.TGetById(id);
            return Ok(about);
        }
    }
}
