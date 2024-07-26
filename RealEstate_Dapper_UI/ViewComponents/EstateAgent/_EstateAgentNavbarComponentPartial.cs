using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentNavbarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentNavbarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
