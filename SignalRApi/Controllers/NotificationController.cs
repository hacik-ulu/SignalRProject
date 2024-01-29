using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult GetNotificationList()
        {
            var getNotificationList = _notificationService.TGetListAll();
            return Ok(getNotificationList);
        }

        // Status = False, Okunmamış Bildirimleri Getirecek.
        [HttpGet("GetNotificationCountByStatusFalse")]
        public IActionResult GetNotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationtByFalse")]
        public IActionResult GetAllNotificationtByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationtByFalse());
        }
    }
}
