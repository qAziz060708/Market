namespace Market.DataAccess.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }


        public List<Seller> Sellers { get; set;}

        public List<TransactionReport> TransactionReports { get; set;}

        public Customer Customer { get; set; }

        public Category Category { get; set; }
    }
}