using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Indolent.Retail.Core.ApplicationServices;

public class OrderService : IOrderService
{
    private readonly ILogger<OrderService> _logger;

    private readonly IOrderDomain _orderDomain;

    public OrderService(ILogger<OrderService> logger, IOrderDomain orderDomain)
    {
        _logger = logger;
        _orderDomain = orderDomain;
    }

    public IEnumerable<Order> Read(int id = 0, string customerId = "")
    {
        LogMethodCall(nameof(Read));
        return _orderDomain.Read(id, customerId);
    }

    private void LogMethodCall(string methodName)
    {
        _logger.LogInformation("Calling {Class}.{Method}",
            nameof(OrderService), methodName);
    }
}