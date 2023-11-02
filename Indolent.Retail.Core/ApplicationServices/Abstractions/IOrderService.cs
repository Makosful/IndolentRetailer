using Indolent.Retail.Core.Entities;

namespace Indolent.Retail.Core.ApplicationServices.Abstractions;

public interface IOrderService
{
    public IEnumerable<Order> Read(int id = 0, string customerId = "");
}