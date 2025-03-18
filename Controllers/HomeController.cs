using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id=1)
        {
            string headerImage, headerColor,circleColor;

            switch (id)
            {
                case 2:
                    headerImage = "/asset/Booker_Header.png";
                    headerColor = "#2256aa";
                    circleColor = "#07a7e7";
                    break;
                case 3:
                    headerImage = "/asset/OneStop_Header.png";
                    headerColor = "#0039a6";
                    circleColor = "#ab2225";
                    break;
                default:
                    headerImage = "/asset/Tesco_Header.png";
                    headerColor = "#467cca";
                    circleColor = "#0f83e3";
                    break;
            }

            ViewBag.HeaderImage = headerImage;
            ViewBag.HeaderColor = headerColor;
            ViewBag.CircleColor = circleColor;
            HttpContext.Session.SetString("HeaderImage", headerImage);
            HttpContext.Session.SetString("HeaderColor", headerColor);
            HttpContext.Session.SetString("CircleColor",circleColor);

            return View();
        }
    }
    
}
