using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Models
{
    public class TransactionReport
    {
        public int ReportId { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int PaymentId { get; set; }


        public ShoppingOrder ShoppingOrder { get; set; }

        public List<Product> Products { get; set; }
    }
}
