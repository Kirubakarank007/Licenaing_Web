using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Licensing_Web.Models
{
    public class ActionTypeModel
    {
        [Key]
        public int id { get; set; }

        [JsonPropertyName("actiontype")]
        public string ?actionType { get; set; }

        [JsonPropertyName("isactive")]
        public bool isActive { get;set; }

    }
}
