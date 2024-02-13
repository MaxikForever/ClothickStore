using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using MediatR;

namespace Clothick.Application.Commands.Order;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, Domain.Entities.Order>
{
    private readonly IBaseRepository<Domain.Entities.Order> _orderRepository;

    public CreateOrderCommandHandler(IBaseRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Domain.Entities.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var newOrder = request.ToEntity();

        _orderRepository.CreateAsync(newOrder);
        await _orderRepository.SaveAsync();

        return newOrder;
    }
}