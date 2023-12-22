// Hub Sınıfı bir sunucu/server görevi görecek (Dağıtım işlemi yapılacak.)
using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        // sayfanın yenilenmeden tetikleyici ile verilerin getirilmesi.

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendCategoryCount()
        {
            var sendCategoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", sendCategoryCount);
        }

        public async Task SendProductCount()
        {
            var sendProductCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", sendProductCount);
        }

        public async Task ActivePassiveCategoryCount()
        {
            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);
        }

       

    }
}
