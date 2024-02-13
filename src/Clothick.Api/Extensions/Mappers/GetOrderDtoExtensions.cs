using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetOrderDtoExtensions
{
    public static GetOrderDto ToDto(this Order order)
    {
        return new GetOrderDto
        {
            Status = order.Status,
            CustomerId = order.CustomerId,
            Quantity = order.Quantity,
            ProductId = order.Quantity,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice
        };
    }
}