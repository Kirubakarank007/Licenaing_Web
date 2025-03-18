using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Licensing_Web.wwwroot.Components
{
    [ViewComponent]
    public class SideBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string activePage)
        {
            ViewBag.ActivePage = activePage;
            return View();
        }
    }
}
