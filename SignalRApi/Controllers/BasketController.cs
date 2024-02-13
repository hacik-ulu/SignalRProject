using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
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



        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            //Bahçe 01 --> 45
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 3,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = createBasketDto.TotalPrice
            });
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var deleteToItemFromBasket = _basketService.TGetById(id);
            _basketService.TDelete(deleteToItemFromBasket);
            return Ok("Seçili Ürün Sepetten Çıkarıldı!");
        }

    }
}
