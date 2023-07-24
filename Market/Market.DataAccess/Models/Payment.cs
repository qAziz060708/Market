namespace Market.DataAccess.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public string PaymentType { get; set; }

        public int CategoryId { get; set; }

        public DateTime PaymentDate { get; set; }


        public Customer Customer { get; set; }
    }
}