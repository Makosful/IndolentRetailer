using Indolent.Retail.Core.Entities;

namespace Indolent.Retail.Core.ApplicationServices.Abstractions;

public interface ICustomerService
{
    public Customer Create(Customer customer);

    public IEnumerable<Customer> Read(string uuid = "", bool includeOrders = false);

    public Customer Update(Customer customer);

    public bool Delete(string uuid);
}