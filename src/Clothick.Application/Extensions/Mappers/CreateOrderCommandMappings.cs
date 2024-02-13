using Clothick.Application.Commands.Order;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class CreateOrderCommandMappings
{
    public static Order ToEntity(this CreateOrderCommand command)
    {
        return new Order()
        {
            Status = command.Status,
            CustomerId = command.CustomerId,
            Quantity = command.Quantity,
            ProductVariantId = command.ProductVariantId,
            OrderDate = DateTime.UtcNow,
            TotalPrice = command.Price
        };
    }
}