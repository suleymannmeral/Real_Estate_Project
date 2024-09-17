using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using System.Net.Http;
using System.Text;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdverdsController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IHttpClientFactory _httpClientFactory;

        public MyAdverdsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IActionResult> ActiveAdverts()
        {
            var userıd = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Products/ProductAdvertsListByEmployeeByTrue?id=" + userıd);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> PassiveAdverts()
        {
            var userıd = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Products/ProductAdvertsListByEmployeeByFalse?id=" + userıd);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]

        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto,GetLastProductDto getLastProductDto)
        {
            createProductDto.DealOfTheDay = false;
            createProductDto.advertDate = DateTime.Now;
            createProductDto.ProductStatus = true;

            var id = _loginService.GetUserId;
            createProductDto.UserID = int.Parse(id);



            var client = _httpClientFactory.CreateClient();
     
            var jsonData = JsonConvert.SerializeObject(createProductDto);
          
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44382/api/Products", stringContent);
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:44382/api/Products/GetLastProduct");

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetLastProductDto>(jsonData2);
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                TempData["ProductID"] = values.ProductID;
                return Redirect("https://localhost:44375/EstateAgent/MyAdverds/CreateAdvertDetail");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdvertDetail()
        {
           
            if (TempData["ProductID"] != null)
            {
                int productId = (int)TempData["ProductID"];
                ViewBag.ProductID = productId;
            }
            else
            {
                // Hata durumunu yönetin
                return RedirectToAction("Error");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAdvertDetail(CreateProductDetailDto createProductDetailDto)
        {

            createProductDetailDto.advertDate = DateTime.Now;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44382/api/ProductDetailsApi/CreateProductDetail", stringContent); var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:44382/api/Products/GetLastProduct");

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetLastProductDto>(jsonData2);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["ProductID"] = values.ProductID;
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                TempData["ApiMessage"] = responseData; 
                return Redirect("https://localhost:44375/EstateAgent/MyAdverds/CreateProductImage");
            }
            else
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                TempData["ApiMessage"] = errorMessage; 
            }

            return View();

        }
        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {

            if (TempData["ProductID"] != null)
            {
                int productId = (int)TempData["ProductID"];
                ViewBag.ProductID = productId;
            }
            else
            {
                // Hata durumunu yönetin
                return RedirectToAction("Error");
            }

            return View();
        }

        public async Task<IActionResult> ChangeProductStatusAsActive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44382/api/Products/ProductStatusChangeToTrue/" + id);
            if (responsemessage.IsSuccessStatusCode)
            {
                return Redirect("https://localhost:44375/EstateAgent/MyAdverds/ActiveAdverts");
            }
            return View();

        }
        public async Task<IActionResult>ChangeProductStatusAsPAssive(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44382/api/Products/ProductStatusAsPassive/" + id);
            if(responsemessage.IsSuccessStatusCode)
            {
                return Redirect("https://localhost:44375/EstateAgent/MyAdverds/PassiveAdverts");

            }
            return View();

        }

    }
}
