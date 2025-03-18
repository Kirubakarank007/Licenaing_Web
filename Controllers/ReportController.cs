using Licensing_Web.Models;
using Licensing_Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportDataService _reportDataService;

        public ReportController()
        {
            _reportDataService = new ReportDataService();
        }
        public IActionResult Report()
        {
            ViewBag.Title = "Administration / Report";
            ViewBag.HeaderImage = HttpContext.Session.GetString("HeaderImage") ?? "/asset/Tesco_Header.png";
            ViewBag.HeaderColor = HttpContext.Session.GetString("HeaderColor") ?? "#477dca";
            ViewBag.CircleColor = HttpContext.Session.GetString("CircleColor");
            List<ReportDataModel> dataList = _reportDataService.GetData();
            return View(dataList);
        }
    }
}
