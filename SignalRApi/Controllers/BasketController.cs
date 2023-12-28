using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("GetBasketByMenuTableID")]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var basket = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(basket);
        }
    }
}
