using System.ComponentModel.DataAnnotations;

namespace Licensing_Web.Models
{
    public class BranchAddressModel
    {
        [Key]
        public int Id { get; set; }
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        [Required]
        public required string  AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? AddressLine4 { get; set; }
        public string? TownorCity { get; set; }
        public required string Country { get; set; }
        public required string PostCode { get; set; }
        public bool IsActive { get; set; }
    }
}
