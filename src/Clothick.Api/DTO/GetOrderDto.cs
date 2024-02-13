using Clothick.Domain.Enums;

namespace Clothick.Api.DTO;

public class GetOrderDto
{
    public OrderStatus Status { get; set; }

    public int CustomerId { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public DateTime OrderDate { get; set; }

    public Decimal TotalPrice { get; set; }
}