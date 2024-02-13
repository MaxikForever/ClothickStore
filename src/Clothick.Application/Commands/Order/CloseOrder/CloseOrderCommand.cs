using MediatR;

namespace Clothick.Application.Commands.Order.CloseOrder;

public record CloseOrderCommand(int OrderId): IRequest<string>;