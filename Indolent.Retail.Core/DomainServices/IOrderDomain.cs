using Indolent.Retail.Core.Entities;

namespace Indolent.Retail.Core.DomainServices;

public interface IOrderDomain
{
    public IEnumerable<Order> Read(int id = 0, string customerId = "");
}