using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    public class EmployeeAddressController : Controller
    {
        public IActionResult EmployeeAddress()
        {
            ViewBag.Title = "Administration / Employee Addresses";
            return View();
        }
    }
}
