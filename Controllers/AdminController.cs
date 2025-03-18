using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            ViewBag.Title = "Administration / Home";
            ViewBag.HeaderImage = HttpContext.Session.GetString("HeaderImage") ?? "/asset/Tesco_Header.png";
            ViewBag.HeaderColor = HttpContext.Session.GetString("HeaderColor") ?? "#477dca";
            ViewBag.CircleColor = HttpContext.Session.GetString("CircleColor");

            return View();
        }
        public IActionResult ActionType()
        {
            return PartialView("_ActionType");
        }
        public IActionResult BranchAddreses()
        {
            return PartialView("_BranchAddreses");
        }
        public IActionResult EmployeeAddresses()
        {
            return PartialView("_EmployeeAddresses");
        }
        public IActionResult AuthorityDetails()
        {
            return PartialView("_AuthorityDetails");
        }
        public IActionResult AuthorityType()
        {
            return PartialView("_AuthorityType");
        }
        public IActionResult BranchType()
        {
            return PartialView("_BranchType");
        }
        public IActionResult ContactDetails()
        {
            return PartialView("_ContactDetails");
        }
        public IActionResult CorrespondenceContactTypes()
        {
            return PartialView("_CorrespondenceContactTypes");
        }
        public IActionResult Countries()
        {
            return PartialView("_Countries");
        }
        public IActionResult Groups()
        {
            return PartialView("_Groups");
        }
        public IActionResult Hour()
        {
            return PartialView("_Hour");
        }
        public IActionResult LicenseStatus()
        {
            return PartialView("_LicenseStatus");
        }
        public IActionResult PaymentTypes()
        {
            return PartialView("_PaymetTypes");
        }
        public IActionResult Status()
        {
            return PartialView("_Status");
        }
        public IActionResult ManageUser()
        {
            return PartialView("_UnAuthorisedUser");
        }
        public IActionResult RegisterUSer()
        {
            return PartialView("_UnAuthorisedUser");
        }


    }
}
