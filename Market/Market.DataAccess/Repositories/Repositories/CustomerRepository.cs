using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using System.Data.Entity;

namespace Market.DataAccess.Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public CustomerRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            _marketDbContext.Customers.Add(customer);
            await _marketDbContext.SaveChangesAsync();
            return customer.CustomerId;
        }

        public async Task<int> DeleteCustomerAsync(Customer customer)
        {
            _marketDbContext.Customers.Remove(customer);
            await _marketDbContext.SaveChangesAsync();
            return customer.CustomerId;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _marketDbContext.Customers
                .Include(u => u.Categories)
                .Include(u => u.Products)
                .Include(u => u.Payments)
                .Include(u => u.Deliveries)
                .Include(u => u.ShoppingOrders)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _marketDbContext.Customers
                .Include(u => u.Categories)
                .Include(u => u.Products)
                .Include(u => u.Payments)
                .Include(u => u.Deliveries)
                .Include(u => u.ShoppingOrders)
                .FirstOrDefaultAsync(u => u.CustomerId == id);
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            _marketDbContext.Customers.Update(customer);
            await _marketDbContext.SaveChangesAsync();
            return customer.CustomerId;
        }
    }
}
