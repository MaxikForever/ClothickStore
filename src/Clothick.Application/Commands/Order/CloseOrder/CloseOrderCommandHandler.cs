using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.CustomExceptions;
using Clothick.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.Order.CloseOrder;

public class CloseOrderCommandHandler : IRequestHandler<CloseOrderCommand, string>
{
    private readonly IBaseRepository<Domain.Entities.Order> _orderRepository;
    private readonly IBaseRepository<Domain.Entities.ProductVariant> _productVariantRepository;

    public CloseOrderCommandHandler(IBaseRepository<Domain.Entities.Order> orderRepository, IBaseRepository<Domain.Entities.ProductVariant> productVariantRepository)
    {
        _orderRepository = orderRepository;
        _productVariantRepository = productVariantRepository;
    }

    public async Task<string> Handle(CloseOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByCondition(or => or.Id == request.OrderId).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (order == null)
        {
            throw new OrderIdNotFound($"Order with ID {request.OrderId} not found");

        }

        order.Status = OrderStatus.Delivered;

        var productVariant = await _productVariantRepository.FindByCondition(pv => pv.Id == order.ProductVariantId).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        productVariant!.Stock--;

        _productVariantRepository.UpdateAsync(productVariant);
        await _orderRepository.SaveAsync();


        return $"Order with ID {request.OrderId} marked as delivered";
    }
}