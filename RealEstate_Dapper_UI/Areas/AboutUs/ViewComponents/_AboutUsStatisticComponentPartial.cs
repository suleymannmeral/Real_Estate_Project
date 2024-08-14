using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.AboutUs.ViewComponents
{
    public class _AboutUsStatisticComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutUsStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Statistics1 - ToplamİlanSayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44382/api/StatisticsApi/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion


        

            #region Statistics3 - İlandakiŞehirSayıları
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44382/api/StatisticsApi/DifferentCityCount\r\n");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData3;
            #endregion

            #region Statistics4 - OrtalamaKiraFiyatı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44382/api/StatisticsApi/RentProductAvgPrice\r\n");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion

            return View();
        }
    }
}
