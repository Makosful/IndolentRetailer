using Indolent.Retail.Core.Entities;

namespace Indolent.Retail.Core.DomainServices;

public interface IProductDomain
{
    IEnumerable<Product> Read(int id = 0);
}