namespace Indolent.Retail.Core.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Order> Orders { get; set; }
}