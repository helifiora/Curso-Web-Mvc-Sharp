using Microsoft.EntityFrameworkCore;
using WebAppSalesMVC.Models;

namespace WebAppSalesMVC.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options) : base(options)
        {
        }
        
        public DbSet<Department> Department { get; set; }

        public DbSet<Seller> Seller { get; set; }
        
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}