using System.Text;
using Humanizer;
using Indolent.Retail.Core.Entities;
using Indolent.Retail.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Indolent.Retail.Infrastructure;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<DatabaseContext> _logger;

    public DatabaseContext(ILogger<DatabaseContext> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _logger.LogDebug("Method called: {Class}.{Method}", nameof(DatabaseContext), nameof(OnConfiguring));
        var errMsg =
            $"Unable to bind section [{DatabaseOptions.Database}]. Make sure it exists in the root object of appsettings.json or that at least one field exists within the section, for example via environment variables or dotnet secrets.";
        var options = _configuration.GetSection(DatabaseOptions.Database).Get<DatabaseOptions>()
                      ?? throw new InvalidOperationException(errMsg);
        _logger.LogDebug("{Options}", options.ToString());

        var connectionStringBuilder = new StringBuilder();
        connectionStringBuilder.Append($"User ID={options.UserId};");
        connectionStringBuilder.Append($"Password={options.Password};");
        connectionStringBuilder.Append($"Host={options.Host};");
        connectionStringBuilder.Append($"Database={options.DatabaseName};");
        var connectionString = connectionStringBuilder.ToString();

        if (connectionString is null) throw new ArgumentNullException(nameof(optionsBuilder), errMsg); // TODO
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Customer modeling
        modelBuilder.Entity<Customer>().ToTable(nameof(Customers).ToLower());
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.UUID);
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
        modelBuilder.Entity<Customer>()
            .Property(c => c.UUID)
            .HasColumnName(nameof(Customer.UUID).Underscore());
        modelBuilder.Entity<Customer>()
            .Property(c => c.FirstName)
            .HasColumnName(nameof(Customer.FirstName).Underscore());
        modelBuilder.Entity<Customer>()
            .Property(c => c.LastName)
            .HasColumnName(nameof(Customer.LastName).Underscore());
        modelBuilder.Entity<Customer>()
            .Property(c => c.Phone)
            .HasColumnName(nameof(Customer.Phone).Underscore());
        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .HasColumnName(nameof(Customer.Email).Underscore());
        modelBuilder.Entity<Customer>()
            .Property(c => c.Address)
            .HasColumnName(nameof(Customer.Address).Underscore());

        // Order modeling
        modelBuilder.Entity<Order>().ToTable(nameof(Orders).ToLower());
        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders);
        modelBuilder.Entity<Order>()
            .Property(o => o.Id)
            .HasColumnName(nameof(Order.Id).Underscore());
        modelBuilder.Entity<Order>()
            .Property(o => o.CustomerId)
            .HasColumnName(nameof(Order.CustomerId).Underscore());

        // Product modeling
        modelBuilder.Entity<Product>().ToTable(nameof(Products).ToLower());
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Orders)
            .WithMany(o => o.Products);
        modelBuilder.Entity<Product>()
            .Property(c => c.Id)
            .HasColumnName(nameof(Product.Id).Underscore());
        modelBuilder.Entity<Product>()
            .Property(c => c.Name)
            .HasColumnName(nameof(Product.Name).Underscore());
    }
}