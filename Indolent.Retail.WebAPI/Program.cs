using Indolent.Retail.Core.ApplicationServices;
using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Infrastructure;
using Indolent.Retail.Infrastructure.DomainServices;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();


// Configure services
var services = builder.Services;

services.AddLogging();
services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
services.AddDbContext<DatabaseContext>();

services.AddScoped<ICustomerService, CustomerService>();
services.AddScoped<ICustomerDomain, CustomerDomain>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IOrderDomain, OrderDomain>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IProductDomain, ProductDomain>();


// Configure App
var app = builder.Build();

app.MapControllers();


// Start the web server
app.Run();