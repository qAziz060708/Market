using Market.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccess.DbConnection
{
    public class MarketDbContext:DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options):
            base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<ShoppingOrder> ShoppingOrders { get; set; }
        public DbSet<Transaction_Reports> Transaction_Reports { get; set; }
    }
}
