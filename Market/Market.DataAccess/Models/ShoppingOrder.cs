namespace Market.DataAccess.Models
{
    public class ShoppingOrder
    {
        public int ShoppingOrderId { get; set; }

        public string OrderName { get; set; }

        public int CustomerId { get; set; }

        public DateTime ShoppingDate { get; set; }


        public List<TransactionReport> TransactionReports { get; set; }

        public Customer Customer { get; set; }
    }
}
