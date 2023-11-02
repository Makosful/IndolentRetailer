using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Indolent.Retail.Infrastructure.DomainServices;

public class ProductDomain : IProductDomain
{
    private readonly DatabaseContext _context;
    private readonly ILogger<ProductDomain> _logger;

    public ProductDomain(ILogger<ProductDomain> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IEnumerable<Product> Read(int id = 0)
    {
        LogMethodCall(nameof(Read));

        var queryable = from p in _context.Products select p;

        if (id > 0) queryable = queryable.Where(p => p.Id == id);

        return queryable.ToList();
    }

    private void LogMethodCall(string methodName)
    {
        _logger.LogInformation("Calling {Class}.{Method}",
            nameof(ProductDomain), methodName);
    }
}