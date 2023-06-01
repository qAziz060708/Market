using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IDeliveryService
    {
        Task<int> AddDeliveryAsync(Delivery delivery);

        Task<int> UpdateDeliveryAsync(Delivery delivery, int id);

        Task<int> DeleteDeliveryAsync(int id);

        Task<Delivery> GetDeliveryByIdAsync(int id);

        Task<List<Delivery>> GetAllDeliveriesAsync();
    }
}
