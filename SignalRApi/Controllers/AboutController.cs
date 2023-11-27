using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        // Business katmanlı ile iletişim kuracak
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var response = _aboutService.TGetListAll();
            return Ok(response);
        }

        // Dto uygulama katmanları arasında veriyi transfer etmek için kullanılır.
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
            };
            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda kısmı başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about2 = new()
            {
                AboutID = updateAboutDto.AboutID,
                ImageUrl = updateAboutDto.ImageUrl,
                Description = updateAboutDto.Description,
                Title = updateAboutDto.Title,
            };
            _aboutService.TUpdate(about2);
            return Ok("Hakkımda kısmı başarıyla güncellendi!");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var response = _aboutService.TGetById(id);
            return Ok(response);
        }
    }
}
