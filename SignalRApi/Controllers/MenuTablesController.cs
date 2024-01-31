using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var menuTableCount = _menuTableService.TMenuTableCount();
            return Ok(menuTableCount);
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var menuTableList = _menuTableService.TGetListAll();
            return Ok(menuTableList);
        }

        // Dto uygulama katmanları arasında veriyi transfer etmek için kullanılır.
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            _menuTableService.TAdd(new MenuTable()
            {
                Name = createMenuTableDto.Name,
                Status = false // Masanın boş olduğu anlamına geliyor
            });
            return Ok("Masa başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var deleteToMenuTable = _menuTableService.TGetById(id);
            _menuTableService.TDelete(deleteToMenuTable);
            return Ok("Masa başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            _menuTableService.TUpdate(new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = false,
            });
            return Ok("Masa bilgisi başarıyla güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var getMenuTable = _menuTableService.TGetById(id);
            return Ok(getMenuTable);
        }
    }
}
