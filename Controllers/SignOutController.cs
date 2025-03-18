using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    public class SignOutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HeaderImage = HttpContext.Session.GetString("HeaderImage") ?? "/asset/Tesco_Header.png";
            ViewBag.HeaderColor = HttpContext.Session.GetString("HeaderColor") ?? "#477dca";
            ViewBag.CircleColor = HttpContext.Session.GetString("CircleColor");

            return View();
        }
    }
}
