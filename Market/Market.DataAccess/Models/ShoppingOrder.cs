namespace Market.DataAccess.Models
{
    public class ShoppingOrder
    {
        public int ShoppingOrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime ShoppingDate { get; set; }

        public int PaymentId { get; set; }


        public TransactionReport TransactionReport { get; set; }

        public Customer Customer { get; set; }

        public List<ShoppingOrdersAndProducts> ShoppingOrdersAndProducts { get; set; }

        public Payment Payment { get; set; }
    }
}