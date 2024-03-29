using System.Data.Common;
using Clothick.Domain.Enums;

namespace Clothick.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public OrderStatus Status { get; set; }

    public int CustomerId { get; set; }

    public int Quantity { get; set; }

    public int ProductVariantId { get; set; }

    public DateTime OrderDate { get; set; }

    public Decimal TotalPrice { get; set; }

    //navigation properties
    public ProductVariant ProductVariant { get; set; }
}