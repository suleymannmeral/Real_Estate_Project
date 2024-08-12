using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Areas.AboutUs.ViewComponents
{
    public class _AboutUsWhyUsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
