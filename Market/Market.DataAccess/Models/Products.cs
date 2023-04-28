using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Models
{
    public class Products
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }


        public List<Seller> seller { get; set;}

        public List<TransactionReports> transactionReports { get; set;}

        public Customers customers { get; set; }

        public Categories categories { get; set; }

    }
}
