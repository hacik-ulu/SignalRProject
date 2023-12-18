// Hub Sınıfı bir sunucu/server görevi görecek (Dağıtım işlemi yapılacak.)
using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        // sayfanın yenilenmeden tetikleyici ile verilerin getirilmesi.

        SignalRContext _context;
        public SignalRHub(SignalRContext context)
        {
            _context = context;
        }

        public async Task SendCategoryCount()
        {
            var value = _context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
