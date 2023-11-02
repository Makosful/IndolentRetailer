using Indolent.Retail.Core.Entities;

namespace Indolent.Retail.Core.ApplicationServices.Abstractions;

public interface IProductService
{
    IEnumerable<Product> Read(int id = 0);
}