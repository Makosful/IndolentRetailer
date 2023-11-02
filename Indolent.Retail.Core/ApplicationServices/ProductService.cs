using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Indolent.Retail.Core.ApplicationServices;

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;

    private readonly IProductDomain _productDomain;

    public ProductService(ILogger<ProductService> logger, IProductDomain productDomain)
    {
        _logger = logger;
        _productDomain = productDomain;
    }

    public IEnumerable<Product> Read(int id = 0)
    {
        LogMethodCall(nameof(Read));
        return _productDomain.Read(id);
    }

    private void LogMethodCall(string methodName)
    {
        _logger.LogInformation("Calling {Class}.{Method}",
            nameof(ProductService), methodName);
    }
}