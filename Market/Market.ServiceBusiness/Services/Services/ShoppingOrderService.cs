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
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<ShoppingOrderResponseDTO>> GetAllShoppingOrdersAsync()
        {
            try
            {
                return _mapper.Map<List<ShoppingOrderResponseDTO>>(await _shoppingOrderRepository.GetAllShoppingOrdersAsync());
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ShoppingOrderResponseDTO> GetShoppingOrderByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<ShoppingOrderResponseDTO>(await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateShoppingOrderAsync(ShoppingOrderRequestDTO shoppingOrderRequestDTO, int id)
        {
            try
            {
                var shoppingOrderResult = await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id);
                if (shoppingOrderResult is not null)
                {
                    shoppingOrderResult = _mapper.Map<ShoppingOrder>(shoppingOrderRequestDTO);
                    shoppingOrderResult.ShoppingOrderId = id;
                    return await _shoppingOrderRepository.UpdateShoppingOrderAsync(shoppingOrderResult);
                }
                else
                {
                    throw new Exception("Object cannot be updated");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes");
            }
        }
    }
}