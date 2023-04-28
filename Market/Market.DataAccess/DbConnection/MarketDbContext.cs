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

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<ShoppingOrder> ShoppingOrders { get; set; }

        public DbSet<TransactionReports> TransactionReports { get; set; }
    }
}
