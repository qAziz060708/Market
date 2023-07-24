namespace Market.DataAccess.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int ShoppingOrderId { get; set; }

        public string PaymentType { get; set; }

        public DateTime PaymentDate { get; set; }


        public ShoppingOrder ShoppingOrder { get; set; }
    }
}