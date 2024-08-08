using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.ContactUs.Controllers
{
    [Area("ContactUs")]
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
