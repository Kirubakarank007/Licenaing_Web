using System.Text.Json;
using System.Threading.Tasks;
using Licensing_Web.Data;
using Licensing_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

namespace Licensing_Web.Service
{
    public class ImportDataService
    {
        private readonly ApplicationDbContext _context;

   
        public ImportDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ImportDataModel>> GetAllData()
        {
            return await _context.ImportDataModels.ToListAsync();
        }

        public async Task<bool> AddData(IFormFile file, string fileType, string record)
        {
            if (file == null || file.Length == 0)
                return false;

            var importData = new ImportDataModel
            {
                FileName = file.FileName,
                type = fileType,
                date = DateTime.Now,
                records = record
            };

            _context.ImportDataModels.Add(importData);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRecord(int id )
        {
            var rec = await _context.ImportDataModels.FindAsync(id);
            if (rec == null)
            {
                return false;
            }
            _context.ImportDataModels.Remove(rec);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
