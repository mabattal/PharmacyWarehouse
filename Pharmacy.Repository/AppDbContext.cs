using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;

namespace Pharmacy.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Suplier> Categories { get; set; }
        public DbSet<Medicine> Products { get; set; }
    }
}
