namespace Market.DataAccess.Models
{
    public class TransactionReport
    {
        public int TransactionReportId { get; set; }

        public int ShoppingOrderId { get; set; }


        public ShoppingOrder ShoppingOrder { get; set; }
    }
}