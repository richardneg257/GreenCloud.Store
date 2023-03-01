using GreenCloud.Store.Entity;
using Microsoft.EntityFrameworkCore;

namespace GreenCloud.Store.Repository
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
