

using System;
using System.Threading.Tasks;
using Licensing_Web.Data;
using Licensing_Web.Models;
using Licensing_Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace Licensing_Web.Controllers
{
    [Route("api/importdata")]
    [ApiController]
    public class ImportDataController : Controller
    {

        public readonly ImportDataService _ImpDataService;

        public ImportDataController( ImportDataService service)
        {
            _ImpDataService = service;
        }


        public async Task<IActionResult> ImportData(string section = "default")
        {
            ViewBag.Title = "Administration / Import Data";
            ViewBag.HeaderImage = HttpContext.Session.GetString("HeaderImage") ?? "/asset/Tesco_Header.png";
            ViewBag.HeaderColor = HttpContext.Session.GetString("HeaderColor") ?? "#477dca";
            ViewBag.CircleColor = HttpContext.Session.GetString("CircleColor");
            ViewBag.Section = section;
            List<ImportDataModel> dataList = await _ImpDataService.GetAllData();
            return View(dataList);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllData()
        {
            var data = await _ImpDataService.GetAllData();
            return Ok(data);
        }

        [HttpPost("upload")]
        public  async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] string filetype, [FromForm] string record)
        {
            var saveData = await _ImpDataService.AddData(file, filetype, record);
            if (!saveData)
            {
                return BadRequest(new { Message = "Invalid file or missing data" });
            }
            return Ok(new { Message = "File data saved successfully!" });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var rec = await _ImpDataService.DeleteRecord(id);
            if (!rec)
            {
                return BadRequest(new { Message = "Record is not found" });
            }
            
            return Ok(new { Message = "record Deleted Successfully" });
        }
      
    }
}
