using Indolent.Retail.Core.ApplicationServices;
using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Infrastructure;
using Indolent.Retail.Infrastructure.DomainServices;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();


// Configure services
var services = builder.Services;

services.AddLogging();
services.AddControllers();
services.AddDbContext<DatabaseContext>();

services.AddScoped<ICustomerService, CustomerService>();
services.AddScoped<ICustomerDomain, CustomerDomain>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IOrderDomain, OrderDomain>();

// Configure App
var app = builder.Build();

app.MapControllers();


// Start the web server
app.Run();