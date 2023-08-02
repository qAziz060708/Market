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
        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<ShoppingOrder> ShoppingOrders { get; set; }

        public DbSet<TransactionReport> TransactionReports { get; set; }

        public DbSet<ShoppingOrdersAndProducts> ShoppingOrdersAndProducts { get; set; }
    }
}