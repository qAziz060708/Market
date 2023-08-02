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
            CreateMap<Customer, CustomerResponseDTO>()
                .ForMember(customerResponseDTO => customerResponseDTO.FullName,
                opt => opt.MapFrom(customer => $"{customer.FirstName} {customer.LastName}"))
                .ReverseMap();

            //Payment
            CreateMap<PaymentRequestDTO, Payment>();
            CreateMap<Payment, PaymentResponseDTO>();

            //Product
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<Product, ProductResponseDTO>();

            //Seller
            CreateMap<SellerRequestDTO, Seller>();
            CreateMap<Seller, SellerResponseDTO>()
                .ForMember(sellerResponseDTO => sellerResponseDTO.FullName,
                opt => opt.MapFrom(seller => $"{seller.FirstName} {seller.LastName}"))
                .ReverseMap();

            //ShoppingOrder
            CreateMap<ShoppingOrderRequestDTO, ShoppingOrder>();
            CreateMap<ShoppingOrder, ShoppingOrderResponseDTO>();

            //Delivery
            CreateMap<DeliveryRequestDTO, Delivery>();
            CreateMap<Delivery, DeliveryResponseDTO>();

            //TransactionReport
            CreateMap<TransactionReportRequestDTO, TransactionReport>();
            CreateMap<TransactionReport, TransactionReportResponseDTO>()
                .ForMember(customerResponseDTO => customerResponseDTO.FullName,
                opt => opt.MapFrom(shoppingOrder => $"{shoppingOrder.ShoppingOrder.Customer.FirstName} {shoppingOrder.ShoppingOrder.Customer.LastName}"))
                .ReverseMap();
        }
    }
}