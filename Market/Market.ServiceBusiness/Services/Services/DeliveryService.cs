using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<int> AddDeliveryAsync(Delivery delivery)
        {
            try
            {
                return await _deliveryRepository.AddDeliveryAsync(delivery);
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
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<List<Delivery>> GetAllDeliveriesAsync()
        {
            try
            {
                return await _deliveryRepository.GetAllDeliveriesAsync();
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

        public async Task<Delivery> GetDeliveryByIdAsync(int id)
        {
            try
            {
                return await _deliveryRepository.GetDeliveryByIdAsync(id);
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

        public async Task<int> UpdateDeliveryAsync(Delivery delivery, int id)
        {
            try
            {
                var deliveryresult = await _deliveryRepository.GetDeliveryByIdAsync(id);
                if (deliveryresult is not null)
                {
                    return await _deliveryRepository.UpdateDeliveryAsync(delivery);
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
