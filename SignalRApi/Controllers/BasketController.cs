using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SignalRContext _context;

        public BasketController(IBasketService basketService, SignalRContext context)
        {
            _basketService = basketService;
            _context = context;
        }

        [HttpGet("GetBasketByMenuTableID")]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var basket = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(basket);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var basketList = _context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id)
                 .Select(z => new ResultBasketListWithProducts
                 {
                     BasketID = z.BasketID,
                     Count = z.Count,
                     MenuTableID = z.MenuTableID,
                     Price = z.Price,
                     ProductID = z.ProductID,
                     TotalPrice = z.TotalPrice,
                     ProductName = z.Product.ProductName
                 }).ToList();
            return Ok(basketList);
        }
    }
}
