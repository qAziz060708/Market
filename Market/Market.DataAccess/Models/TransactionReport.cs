namespace Market.DataAccess.Models
{
    public class TransactionReport
    {
        public int TransactionReportId { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int PaymentId { get; set; }


        public ShoppingOrder ShoppingOrder { get; set; }

        public List<Product> Products { get; set; }
    }
}