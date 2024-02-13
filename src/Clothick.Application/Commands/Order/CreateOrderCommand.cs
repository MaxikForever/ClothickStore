using Clothick.Domain.Enums;
using MediatR;

namespace Clothick.Application.Commands.Order;

public record CreateOrderCommand(OrderStatus Status, int CustomerId, int Quantity, int ProductVariantId, decimal Price) : IRequest<Domain.Entities.Order>;