using AutoMapper;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Market.ServiceBusiness.DTO.Response_DTO;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.DataAccess.Models;

namespace Market.ServiceBusiness.Services.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }

        public async Task<int> AddDeliveryAsync(DeliveryRequestDTO deliveryRequestDTO)
        {
            try
            {
                return await _deliveryRepository.AddDeliveryAsync(_mapper.Map<Delivery>(deliveryRequestDTO));
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

        public async Task<int> DeleteDeliveryAsync(int id)
        {
            try
            {
                var deliveryResult = await _deliveryRepository.GetDeliveryByIdAsync(id);
                if (deliveryResult is not null)
                {
                    return await _deliveryRepository.DeleteDeliveryAsync(deliveryResult);
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

        public async Task<List<DeliveryResponseDTO>> GetAllDeliveriesAsync()
        {
            try
            {
                return _mapper.Map<List<DeliveryResponseDTO>>(await _deliveryRepository.GetAllDeliveriesAsync());
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

        public async Task<DeliveryResponseDTO> GetDeliveryByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<DeliveryResponseDTO>(await _deliveryRepository.GetDeliveryByIdAsync(id));
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

        public async Task<int> UpdateDeliveryAsync(DeliveryRequestDTO deliveryRequestDTO, int id)
        {
            try
            {
                var deliveryResult = await _deliveryRepository.GetDeliveryByIdAsync(id);
                if (deliveryResult == null)
                {
                    deliveryResult = _mapper.Map<Delivery>(deliveryRequestDTO);
                    deliveryResult.DeliveryId = id;
                    return await _deliveryRepository.UpdateDeliveryAsync(deliveryResult);
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