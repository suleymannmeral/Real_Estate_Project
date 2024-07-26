using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashBoardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _EstateAgentDashBoardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            #region Statistics1 - ToplamİlanSayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44382/api/EstateAgentDashboardStatistic/AllProductCount\r\n");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion


            #region Statistics2 - Personelin Toplam İlan Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44382/api/EstateAgentDashboardStatistic/ProductCountByEmployeID?id="+id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.allProductCountEmployee = jsonData2;
            #endregion

            #region Statistics3 -  Personelin Aktif İlan Sayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44382/api/EstateAgentDashboardStatistic/ProductCountByEmployeIDProductStatusTrue?id="+id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.activeProductCountEmployee = jsonData3;
            #endregion

            #region Statistics4 -Personelin Pasif İlan Sayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44382/api/EstateAgentDashboardStatistic/ProductCountByEmployeIDProductStatusFalse?id="+id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.passiveProductCountEmployee = jsonData4;
            #endregion

            return View();
        }

    }
}
