namespace Indolent.Retail.Core.Entities;

public class Order
{
    public int Id { get; set; }

    public string CustomerId { get; set; }

    public Customer Customer { get; set; }
}