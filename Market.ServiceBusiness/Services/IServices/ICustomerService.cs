using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ICustomerService
    {
        Task<int> AddCustomerAsync(Customer customer);

        Task<int> UpdateCustomerAsync(Customer customer, int id);

        Task<int> DeleteCustomerAsync(int id);

        Task<Customer> GetCustomerByIdAsync(int id);

        Task<List<Customer>> GetAllCustomersAsync();
    }
}
