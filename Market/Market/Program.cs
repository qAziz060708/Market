using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.Services.IServices;
using Market.ServiceBusiness.Services.Services;
using Market.DataAccess.Repositories.IRepositories;
using Market.DataAccess.Repositories.Repositories;
using Market.DataAccess.DbConnection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Add services to the container.
var config = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddDbContext<MarketDbContext>(option => option.UseNpgsql(config["Connect"]));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IShoppingOrderService, ShoppingOrderService>();
builder.Services.AddScoped<ITransactionReportService, TransactionReportService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IShoppingOrderRepository, ShoppingOrderRepository>();
builder.Services.AddScoped<ITransactionReportRepository, TransactionReportRepository>();
builder.Services.AddScoped<MarketDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
