using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.AboutUs.ViewComponents
{
    public class _AboutUsMainComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
