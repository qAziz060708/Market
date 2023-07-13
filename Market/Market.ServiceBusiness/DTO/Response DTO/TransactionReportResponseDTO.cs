namespace Market.ServiceBusiness.DTO.Response_DTO
{
    public class TransactionReportResponseDTO
    {
        public int ReportId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryType { get; set; }

        public string FullName { get; set; }

        public string ProductName { get; set; }

        public DateTime ShoppingDate { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
