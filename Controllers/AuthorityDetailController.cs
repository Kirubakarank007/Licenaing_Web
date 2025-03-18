using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    public class AuthorityDetailController : Controller
    {
        public IActionResult AuthorityDetail()
        {
            ViewBag.Title = "Administration / Authority Detail";

            return View();
        }
    }
}
