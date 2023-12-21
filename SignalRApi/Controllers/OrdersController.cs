using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            var totalOrderCount = _orderService.TTotalOrderCount();
            return Ok(totalOrderCount);
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var activeOrderCount = _orderService.TActiveOrderCount();
            return Ok(activeOrderCount);
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            var lastOrderPrice = _orderService.TLastOrderPrice();
            return Ok(lastOrderPrice);
        }

        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            var todayTotalPrice = _orderService.TTodayTotalPrice();
            return Ok(todayTotalPrice);
        }
    }
}
