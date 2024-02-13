using Clothick.Domain.Enums;

namespace Clothick.Api.DTO;

public class CreateOrderDto
{
    public OrderStatus Status { get; set; }

    public int CustomerId { get; set; }

    public int Quantity { get; set; }

    public int ProductVariantId { get; set; }

    public Decimal Price { get; set; }
}