using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Models
{
    public class Delivery
    {
       public int DeliveryId { get; set; }

       public int CustomerId { get; set; }

       public DateTime DeliveryDate { get; set; }


       public Customer Customer { get; set; }
    }
}
