using Licensing_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Licensing_Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ImportDataModel> ImportDataModels { get; set; }

        public DbSet<ActionTypeModel> ActionData { get; set; }

        public DbSet<BranchAddressModel> AddressData { get; set; }
    }

}
