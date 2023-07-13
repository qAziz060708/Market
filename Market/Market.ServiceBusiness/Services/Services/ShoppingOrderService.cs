using AutoMapper;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.Services
{
    public class ShoppingOrderService : IShoppingOrderService
    {
        private readonly IShoppingOrderRepository _shoppingOrderRepository;
        private readonly IMapper _mapper;
        public ShoppingOrderService(IShoppingOrderRepository shoppingOrderRepository, IMapper mapper)
        {
            _shoppingOrderRepository = shoppingOrderRepository;
            _mapper = mapper;
        }

        public async Task<int> AddShoppingOrderAsync(ShoppingOrderRequestDTO shoppingOrderRequestDTO)
        {
            try
            {
                return await _shoppingOrderRepository.AddShoppingOrderAsync(_mapper.Map<ShoppingOrder>(shoppingOrderRequestDTO));
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

        public async Task<int> DeleteShoppingOrderAsync(int id)
        {
            try
            {
                var shoppingOrderResult = await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id);
                if (shoppingOrderResult is not null)
                {
                    return await _shoppingOrderRepository.DeleteShoppingOrderAsync(shoppingOrderResult);
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

        public async Task<List<ShoppingOrderResponseDTO>> GetAllShoppingOrdersAsync()
        {
            try
            {
                return _mapper.Map<List<ShoppingOrderResponseDTO>>(await _shoppingOrderRepository.GetAllShoppingOrdersAsync());
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

        public async Task<ShoppingOrderResponseDTO> GetShoppingOrderByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<ShoppingOrderResponseDTO>(await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id));
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

        public async Task<int> UpdateShoppingOrderAsync(ShoppingOrderRequestDTO shoppingOrderRequestDTO, int id)
        {
            try
            {
                var shoppingOrderResult = await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id);
                if (shoppingOrderResult is not null)
                {
                    shoppingOrderResult.OrderName = shoppingOrderRequestDTO.OrderName;
                    return await _shoppingOrderRepository.UpdateShoppingOrderAsync(shoppingOrderResult);
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
