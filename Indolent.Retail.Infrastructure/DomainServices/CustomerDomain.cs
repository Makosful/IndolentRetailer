using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Indolent.Retail.Infrastructure.DomainServices;

public class CustomerDomain : ICustomerDomain
{
    private readonly DatabaseContext _context;
    private readonly ILogger<CustomerDomain> _logger;

    public CustomerDomain(ILogger<CustomerDomain> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public Customer Create(Customer customer)
    {
        LogMethodCall(nameof(Create));
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> Read(string uuid = "")
    {
        LogMethodCall(nameof(Read));

        var queryable = from c in _context.Customers select c;

        if (!string.IsNullOrWhiteSpace(uuid))
            queryable = queryable.Where(c => c.UUID == uuid);

        return queryable.ToList();
    }

    public Customer Update(Customer customer)
    {
        LogMethodCall(nameof(Update));
        throw new NotImplementedException();
    }

    public bool Delete(string uuid)
    {
        LogMethodCall(nameof(Delete));
        throw new NotImplementedException();
    }

    private void LogMethodCall(string methodName)
    {
        _logger.LogInformation("Calling {Class}.{Method}",
            nameof(CustomerDomain), methodName);
    }
}