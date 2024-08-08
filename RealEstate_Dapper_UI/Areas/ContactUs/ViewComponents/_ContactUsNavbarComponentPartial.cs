using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.ContactUs.ViewComponents
{
    public class _ContactUsNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
