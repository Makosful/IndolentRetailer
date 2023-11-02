using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Indolent.Retail.Core.DomainServices;
using Indolent.Retail.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Indolent.Retail.Core.ApplicationServices;

public class CustomerService : ICustomerService
{
    private readonly ICustomerDomain _customerDomain;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(ILogger<CustomerService> logger, ICustomerDomain customerDomain)
    {
        _logger = logger;
        _customerDomain = customerDomain;
    }

    public Customer Create(Customer customer)
    {
        LogMethodCall(nameof(Create));
        // Not implemented. Do nothing for now
        return customer;
    }

    public IEnumerable<Customer> Read(string uuid = "")
    {
        LogMethodCall(nameof(Read));
        var customers = _customerDomain.Read(uuid);
        return customers;
    }

    public Customer Update(Customer customer)
    {
        LogMethodCall(nameof(Update));
        // Not implemented. Do nothing for now
        return customer;
    }

    public bool Delete(string uuid)
    {
        LogMethodCall(nameof(Delete));
        // Not implemented. Do nothing for now
        return false;
    }

    private void LogMethodCall(string methodName)
    {
        _logger.LogInformation("Calling {Class}.{Method}",
            nameof(CustomerService), methodName);
    }
}