using Licensing_Web.Data;
using Licensing_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Licensing_Web.Service
{
    
    public class ActionTypeService
    {
        private readonly ApplicationDbContext _context;

        public ActionTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ActionTypeModel>> GetAllData()
        {
            return await _context.ActionData.ToListAsync();
        }

        public async Task<bool> AddData(string actionType,bool isActive)
        {
            var data = new ActionTypeModel {actionType= actionType, isActive= isActive };
            _context.ActionData.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteData(int id)
        {
            var data = await _context.ActionData.FindAsync(id);
            if(data == null)
            {
                return false;
            }
            _context.ActionData.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ActionTypeModel?> GetById(int id)
        {
            return await _context.ActionData.FindAsync(id);
        }


        public async Task<bool> MarkActive(int id)
        {
            var dataBind = await _context.ActionData.FindAsync(id);

            if(dataBind.isActive == true)
            {
                dataBind.isActive = false;
                _context.ActionData.Update(dataBind);
                await _context.SaveChangesAsync();
            }
            else
            {
                dataBind.isActive = true;
                _context.ActionData.Update(dataBind);
                await _context.SaveChangesAsync();

            }

            return dataBind.isActive;
        }

        public async Task<bool> EditUpdate(int id, ActionTypeModel model)
        {
            var dataBind = await _context.ActionData.FindAsync(id);
            if (model.actionType == null)
            {
                return false;
            }
            dataBind.actionType = model.actionType;
            dataBind.isActive = model.isActive;

            _context.ActionData.Update(dataBind);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
