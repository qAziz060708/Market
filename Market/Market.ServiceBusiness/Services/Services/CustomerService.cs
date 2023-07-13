using AutoMapper;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<int> AddCustomerAsync(CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                return await _customerRepository.AddCustomerAsync(_mapper.Map<Customer>(customerRequestDTO));
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
                if (customerResult is not null)
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

        public async Task<List<CustomerResponseDTO>> GetAllCustomersAsync()
        {
            try
            {
                return _mapper.Map<List<CustomerResponseDTO>>(await _customerRepository.GetAllCustomersAsync());
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

        public async Task<CustomerResponseDTO> GetCustomerByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<CustomerResponseDTO>(await _customerRepository.GetCustomerByIdAsync(id));
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

        public async Task<int> UpdateCustomerAsync(CustomerRequestDTO customerRequestDTO, int id)
        {
            try
            {
                var customerResult = await _customerRepository.GetCustomerByIdAsync(id);
                if (customerResult is not null)
                {
                    customerResult.FirstName = customerRequestDTO.FirstName;
                    customerResult.LasName = customerRequestDTO.LasName;
                    customerResult.Address = customerRequestDTO.Address;
                    customerResult.ContactAdd = customerRequestDTO.ContactAdd;
                    return await _customerRepository.UpdateCustomerAsync(customerResult);
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
