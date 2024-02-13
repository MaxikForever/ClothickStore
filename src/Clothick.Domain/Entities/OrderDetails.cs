namespace Clothick.Domain.Entities;

public class OrderDetails
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal PriceAtPurchase { get; set; }

    //navigation properties
    public Order Order { get; set; }

    public Product Product { get; set; }
}