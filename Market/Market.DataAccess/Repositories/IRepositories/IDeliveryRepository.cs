using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface IDeliveryRepository
    {
        Task<int> AddDeliveryAsync(Delivery delivery);

        Task<int> UpdateDeliveryAsync(Delivery delivery);

        Task<int> DeleteDeliveryAsync(Delivery delivery);

        Task<Delivery> GetDeliveryByIdAsync(int id);

        Task<List<Delivery>> GetAllDeliveriesAsync();
    }
}
