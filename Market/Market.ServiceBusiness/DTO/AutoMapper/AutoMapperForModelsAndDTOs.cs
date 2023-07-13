using AutoMapper;
using Market.DataAccess.Models;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.DTO.AutoMapper
{
    public class AutoMapperForModelsAndDTOs : Profile
    {
        public AutoMapperForModelsAndDTOs()
        {
            //Category
            CreateMap<CategoryRequestDTO, Category>();
            CreateMap<Category, CategoryResponseDTO>();
            //Customer
            CreateMap<CustomerRequestDTO, Customer>();
            CreateMap<Customer, CustomerResponseDTO>();
            //Payment
            CreateMap<PaymentRequestDTO, Payment>();
            CreateMap<Payment, PaymentResponseDTO>();
            //Product
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<Product, ProductResponseDTO>();
            //Seller
            CreateMap<SellerRequestDTO, Seller>();
            CreateMap<Seller, SellerResponseDTO>();
            //ShoppingOrder
            CreateMap<ShoppingOrderRequestDTO, ShoppingOrder>();
            CreateMap<ShoppingOrder, ShoppingOrderResponseDTO>();
            //Delivery
            CreateMap<Delivery, DeliveryResponseDTO>();
            //TransactionReport
            CreateMap<TransactionReport, TransactionReportResponseDTO>();
        }
    }
}
