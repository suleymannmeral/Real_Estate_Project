using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using RealEstate_Dapper_UI.Dtos.EstateAgentDtos;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashBoardChartComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashBoardChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/EstateAgentChart/Get5CityOfChart\r\n");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
