using Clothick.Application.Commands.UserRegistrationCommands.Products.Delete;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.ProductVariant.Delete;

public class DeleteProductVariantHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IBaseRepository<Domain.Entities.ProductVariant> _productVariantRepository;

    public DeleteProductVariantHandler(IBaseRepository<Domain.Entities.ProductVariant> productVariantRepository)
    {
        _productVariantRepository = productVariantRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _productVariantRepository.FindByCondition(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (categoryToDelete is null)
        {
            throw new InvalidId("Product Variant Id doesn't exist");
        }

        _productVariantRepository.DeleteAsync(categoryToDelete);

        await _productVariantRepository.SaveAsync();
    }
}