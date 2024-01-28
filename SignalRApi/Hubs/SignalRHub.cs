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
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
        }

        public async Task SendStatistic()
        {
            var sendCategoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", sendCategoryCount);

            var sendProductCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", sendProductCount);

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var productCountByHamburger = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByHamburger);

            var productCountByDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByDrink);

            var productPriceAverage = _productService.TProductPriceAverage();
            await Clients.All.SendAsync("ReceiveProductPriceAverage", productPriceAverage.ToString("0.00") + "₺");

            var productNameByMaxPrice = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", productNameByMaxPrice);

            var productNameByMinPrice = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", productNameByMinPrice);

            var productAveragePriceByHamburger = _productService.TProductAveragePriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAveragePriceByHamburger", productAveragePriceByHamburger.ToString("0.00") + "₺");

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00") + "₺");

            var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00") + "₺");

            var todayTotalPrice = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice.ToString("0.00") + "₺");

            var menuTableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);





        }

        public async Task SendProgress()
        {
            var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00") + "₺");

            // Aktif Sipariş Sayısı
            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            // Toplam Masa Sayısı
            var menuTableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);

        }

        public async Task GetBookingList()
        {
            var getBookingList = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", getBookingList);
        }






    }
}
