using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7038/api/Basket/BasketListByMenuTableWithProductName?id=3");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> IndexBaskets()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7038/api/Basket/GetBasketByMenuTableID?id=3");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7038/api/Basket/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                // Ürün başarıyla silindi, JavaScript ile alert göster
                TempData["SuccessMessage"] = "Ürün başarıyla sepetten çıkarıldı!";
                ViewBag.ShowAlert = true;
                return RedirectToAction("Index");
            }

            return View();
        }

       
        




    }
}
