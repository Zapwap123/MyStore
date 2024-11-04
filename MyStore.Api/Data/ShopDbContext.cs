using Microsoft.EntityFrameworkCore;
using MyStore.Api.Models;

namespace MyStore.Api.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
