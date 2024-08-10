using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.AboutUs.Controllers
{
    public class AboutUsController : Controller
    {
        [Area("AboutUs")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
