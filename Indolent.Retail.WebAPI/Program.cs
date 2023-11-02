var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();


// Configure services
var services = builder.Services;

services.AddLogging();
services.AddControllers();


// Configure App
var app = builder.Build();

app.MapControllers();


// Start the web server
app.Run();