using System.Text.Json;
using Licensing_Web.Models;

namespace Licensing_Web.Service
{
    public class ReportDataService
    {
        private readonly string _filePath = "wwwroot/ReportData.json";

        public List<ReportDataModel> GetData()
        {
            var jsonData = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<ReportDataModel>>(jsonData);
        }

    }
}
