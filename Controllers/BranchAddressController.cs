using System.Threading.Tasks;
using Licensing_Web.Models;
using Licensing_Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    [Route("api/admin/branchaddress")]
    [ApiController]
    public class BranchAddressController : Controller
    {
        public readonly BranchAddressService _BranchService;

        public BranchAddressController(BranchAddressService service)
        {
            _BranchService = service;
        }


        [HttpGet("view")]
        public async Task<IActionResult> BranchAddress()
        {
            ViewBag.Title = "Administration / Branch Addresses";
            var data = await _BranchService.GetAllData();
            return View(data);
        }

        [HttpGet("create-new")]
        public IActionResult CreateNew()
        {
            return PartialView("_CreateNew");
        }

        [HttpGet("lists")]

        public async Task<IActionResult> getAllData()
        {
            var data = await _BranchService.GetAllData();
            return Ok(data);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadData([FromBody] BranchAddressModel model)
        {
            var data = await _BranchService.AddData(model);
            if (data)
            {
                return Ok(new { Message = "data uploaded" });

            }
            else
            {
                return BadRequest(new { Message = "Missed Required fields" });
            }
        }


        [HttpPut("activate/{id}")]
        public async Task<IActionResult> MarkAsActive(int id)
        {
            var data = await _BranchService.MarkActive(id);
            if (data)
            {
                return Ok(new { Message = "The user marked as active" });
            }

            return Ok(new { Message = "The user marked as unactive" });
        }

    }
}
