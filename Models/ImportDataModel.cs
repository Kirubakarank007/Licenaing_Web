using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Licensing_Web.Models
{
    public class ImportDataModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public required string FileName { get; set; }
        [Required]
        public DateTime date { get; set; } = DateAndTime.Now;
        [Required]
        public required string type { get; set; }
        public required string records { get; set; }
    }
}
