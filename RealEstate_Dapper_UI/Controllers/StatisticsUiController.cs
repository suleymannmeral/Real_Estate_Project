using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsUiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsUiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/StatisticsApi\r\n");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/ProductCount\r\n");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData2;
            //Aktif Personel
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/Activeemployee\r\n");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.activeEmployee = jsonData3;
            //Daire İlan Sayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/ApartmentCount\r\n");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData4;

            //Ortalama Kira
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/RentProductAvgPrice\r\n");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.avgRent = jsonData5;

            //Ortalama Satış Fiyatı
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/SaleProductAvgPrice\r\n");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = jsonData6;

            //Ortalama Oda Adet
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/AvgRoomCount\r\n");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.avereageRoomCount = jsonData7;

            //Kategori Sayısı
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/AvgCategoryCount\r\n");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData8;

            //En İyi Kaetgori
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/CategoryNameByMaxProduct\r\n");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData9;

            //İlan Şehir
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/CityNameByMaxProduct\r\n");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData10;

            //Şehir Sayısı
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/DifferentCityCount\r\n");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData11;

            //En İyi Personel
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/EmployeeNameByMaxProduct\r\n");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData12;

            //Son İlan Fİyatı
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/LastProductPrice\r\n");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData13;

            //En Eski Bİna Yılı
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/OldestBuildingYear\r\n");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.oldestBuildingYear = jsonData14;
            //En Yeni Bİna Yılı
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/NewestBuildingYear\r\n");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.newestBuildingYear = jsonData16;


            //Pasif Kategori
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client.GetAsync("https://localhost:44382/api/StatisticsApi/PassiveCategoryCount\r\n");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCount = jsonData15;








            return View();
        }
    }
}
