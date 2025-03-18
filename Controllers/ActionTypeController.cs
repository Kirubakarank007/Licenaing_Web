using System.Threading.Tasks;
using Licensing_Web.Models;
using Licensing_Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Licensing_Web.Controllers
{
    [Route("api/admin/actiontype")]
    [ApiController]
    public class ActionTypeController : Controller
    {
        public readonly ActionTypeService _ActionService;

        public ActionTypeController(ActionTypeService actionService)
        {
            _ActionService = actionService;
        }

        [HttpGet("view")]
        public async Task<IActionResult> ActionType()
        {
            ViewBag.Title = "Administration / ActionType";
            var data = await _ActionService.GetAllData();
            return View(data);
        }

        [HttpGet("create-new")]
        public IActionResult CreateNew()
        {
            return PartialView("_CreateNew");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllData()
        {
            var data= await _ActionService.GetAllData();
            return Ok(data);
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> UpdateOld(int id)
        {
            var actionType = await _ActionService.GetById(id);
            if (actionType == null)
            {
                return NotFound();
            }

            return PartialView("_Update", actionType);
        }


        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromBody] ActionTypeModel model)
        {
            var saveData = await _ActionService.AddData(model.actionType,model.isActive);
            if (!saveData)
            {
                return BadRequest(new { Message = "Invalid file or missing data" });
            }
            return Ok(new { Message = "Data uploaded" });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRecords(int id)
        {
            var data = _ActionService.DeleteData(id);
            if (data == null)
            {
                return BadRequest(new { Message="No data found" });
            }
            return Ok(new { Message = "Data deleted" });
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> MarkAsActive(int id)
        {
            var data = await _ActionService.MarkActive(id);
            if (data)
            {
                return Ok(new { Message = "The user marked as active" });
            }
            
            return Ok(new { Message = "The user marked as unactive" });
        }

        [HttpPut("edit/update/{id}")]
        public async Task<IActionResult> UpdateEdit(int id, [FromBody]ActionTypeModel modelType)
        {
            if(modelType == null)
    {
                return BadRequest(new { Message = "Invalid data" });
            }
            var actionType = await _ActionService.EditUpdate(id,modelType);
            if (actionType == null)
            {
                return NotFound();
            }

            return Ok(new { Message="Update Successfully"});
        }

    }
}
