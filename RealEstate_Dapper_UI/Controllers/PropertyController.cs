using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Collections.Immutable;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Products/ProductListWithCategory\r\n");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
          
            ViewBag.searchKeyValue=TempData["searchKeyValue"];
            ViewBag.propertyCategoryId= TempData["propertyCategoryId"];
            ViewBag.city= TempData["city"];
            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44382/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);

                return View(values);
            }

            return View();

        }


        [HttpGet]

        public async Task<IActionResult> PropertySingle(int id)
        {
            ViewBag.i = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Products/getProductByProductID?id="+id);
            var responseMessage2 = await client.GetAsync("https://localhost:44382/api/ProductDetailsApi/getProductDetailByID?id=" + id);
          
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
              
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);
            ViewBag.estateID=values.UserID;
                ViewBag.title1 = values.title;
                ViewBag.productId = values.productID;
                ViewBag.roomCount = values2.RoomCount;
                ViewBag.garageSize = values2.GarageSize;
                ViewBag.buildYear = values2.BuildYear;
                ViewBag.price=values.price;
                ViewBag.city=values.city;
                ViewBag.district=values.district;
                ViewBag.adress=values.Adress;
                ViewBag.type=values.Type;
                ViewBag.bathcount = values2.BathCount;
                ViewBag.bedroomcount = values2.BedRoomCount;
                ViewBag.size = values2.ProductSize;
                ViewBag.date = values.advertDate;
                ViewBag.location = values2.Location;
                ViewBag.desc = values.Description;
                ViewBag.video = values2.VideoUrl;
            DateTime datetime1 = DateTime.Now;
            DateTime datetime2=values.advertDate;
            TimeSpan timespan=datetime1 - datetime2;
            int month=timespan.Days;
            ViewBag.timediff = month / 30;
                return View();
              
          

        
      
        }
    }
}
