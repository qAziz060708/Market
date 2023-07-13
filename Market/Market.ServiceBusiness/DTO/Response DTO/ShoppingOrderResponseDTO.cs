using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.DTO.Response_DTO
{
    public class ShoppingOrderResponseDTO
    {
        public DateTime ShoppingDate { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }
    }
}
