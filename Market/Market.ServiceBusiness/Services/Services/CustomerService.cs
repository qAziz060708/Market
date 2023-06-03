using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.DataAccess.Repositories.Repositories;
using Market.ServiceBusiness.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            try
            {
                return await _customerRepository.AddCustomerAsync(customer);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            try
            {
                var customerResult = await _customerRepository.GetCustomerByIdAsync(id);
                if(customerResult is not null)
                {
                    return await _customerRepository.DeleteCustomerAsync(customerResult);
                }
                else
                {
                    throw new Exception("Object cannot be deleted");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                return await _customerRepository.GetAllCustomersAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                return await _customerRepository.GetCustomerByIdAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<int> UpdateCustomerAsync(Customer customer, int id)
        {
            try
            {
                var customerResult = await _customerRepository.GetCustomerByIdAsync(id);
                if (customerResult is not null)
                {
                    return await _customerRepository.UpdateCustomerAsync(customer);
                }
                else
                {
                    throw new Exception("Object cannot be updated");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }
    }
}
