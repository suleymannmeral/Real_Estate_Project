using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Areas.AboutUs.Data.AboutUsDto;
using System.Net.Http;
using System.Text;

namespace RealEstate_Dapper_UI.Areas.AboutUs.Controllers
{
    [Area("AboutUs")]
    public class AboutUsWhyUsApiController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AboutUsWhyUsApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/AboutUsWhyUsApi\r\n");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutUsWhyUsDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAboutUsWhyUs(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/AboutUsWhyUsApi/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutUsWhyUsDto>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutUsWhyUs(UpdateAboutUsWhyUsDto updateAboutUsWhyUsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutUsWhyUsDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44382/api/AboutUsWhyUsApi/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            else
            {
                var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                ViewData["Error"] = $"Update operation failed: {errorResponse}";
                return View(updateAboutUsWhyUsDto);
            }
        }

    }
}
