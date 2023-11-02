using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Indolent.Retail.Infrastructure.DomainServices;

public class OrderDomain : IOrderDomain
{
    private readonly DatabaseContext _context;
    private readonly ILogger<OrderDomain> _logger;

    public OrderDomain(ILogger<OrderDomain> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IEnumerable<Order> Read(int id = 0, string customerId = "")
    {
        LogMethodCall(nameof(Read));
        var queryable = from o in _context.Orders select o;

        if (id > 0) queryable = queryable.Where(o => o.Id == id);
        if (!string.IsNullOrWhiteSpace(customerId)) queryable = queryable.Where(o => o.CustomerId == customerId);

        return queryable.ToList();
    }

    private void LogMethodCall(string methodName)
    {
        _logger.LogInformation("Calling {Class}.{Method}",
            nameof(OrderDomain), methodName);
    }
}