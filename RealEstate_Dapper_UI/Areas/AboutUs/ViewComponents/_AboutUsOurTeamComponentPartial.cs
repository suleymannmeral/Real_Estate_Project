using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.AboutUs.ViewComponents
{
    public class _AboutUsOurTeamComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
