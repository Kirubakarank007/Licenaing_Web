using Licensing_Web.Data;
using Licensing_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Licensing_Web.Service
{
    public class BranchAddressService
    {
        private readonly ApplicationDbContext _context;

        public BranchAddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BranchAddressModel>> GetAllData()
        {
            var data = await _context.AddressData.ToListAsync();
            return data;
        }
        public async Task<bool> AddData(BranchAddressModel model)
        {
            if(model.Country ==null || model.AddressLine1==null|| model.Country == null)
            {
                return false;
            }

            var data = new BranchAddressModel {
                BranchAddress = model.BranchAddress,
                BranchName=model.BranchName,
                AddressLine1=model.AddressLine1,
                AddressLine2=model.AddressLine2,
                AddressLine3 = model.AddressLine3,
                AddressLine4 = model.AddressLine4,
                Country = model.Country,
                TownorCity = model.TownorCity,
                PostCode = model.PostCode  ,
                IsActive = model.IsActive
            };

            _context.AddressData.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkActive(int id)
        {
            var data = await _context.AddressData.FindAsync(id);

            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else
            {
                data.IsActive = true;
            }
            var res = data.IsActive;
             _context.AddressData.Update(data);
            await _context.SaveChangesAsync();
            return res;
        }

    }
}
