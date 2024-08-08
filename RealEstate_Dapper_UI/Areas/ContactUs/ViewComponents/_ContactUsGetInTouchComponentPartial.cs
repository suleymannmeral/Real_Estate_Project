using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Areas.ContactUs.Data;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.ContactUs.ViewComponents
{
    public class _ContactUsGetInTouchComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactUsGetInTouchComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
       
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/ContactUsApiControlle");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactUsDto>>(jsonData);
                
                return View(values);
            }
            return View();
        }
    }
}
