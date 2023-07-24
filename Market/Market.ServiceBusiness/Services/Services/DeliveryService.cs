using AutoMapper;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Market.ServiceBusiness.DTO.Response_DTO;
using Microsoft.EntityFrameworkCore;

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
    }
}