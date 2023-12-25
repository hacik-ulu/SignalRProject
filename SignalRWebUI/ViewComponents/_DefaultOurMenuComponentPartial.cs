using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
