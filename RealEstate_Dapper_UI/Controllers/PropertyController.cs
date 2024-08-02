using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NuGet.Configuration;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using System.Collections.Immutable;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public PropertyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings=apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl+ "Products/ProductListWithCategory");
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


      
        [HttpGet("property/{slug}/{id}")]

        public async Task<IActionResult> PropertySingle(string slug,int id)
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
                ViewBag.slugUrl=values.SlugUrl;
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
            string slugFromTitle = CreateSlug(values.title);
            ViewBag.slugUrl = slugFromTitle;
                return View();
              
          

        
      
        }
        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }
    }
}
