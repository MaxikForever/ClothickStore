using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products;

public class UpdateProductVariantCommandHandler : IRequestHandler<UpdateProductVariantCommand, Domain.Entities.ProductVariant>
{
    private readonly IBaseRepository<Domain.Entities.ProductVariant> _repository;
    private readonly IProductImageStorageService _productImageStorageService;

    public UpdateProductVariantCommandHandler(IBaseRepository<Domain.Entities.ProductVariant> repository, IProductImageStorageService productImageStorageService)
    {
        _repository = repository;
        _productImageStorageService = productImageStorageService;
    }

    public async Task<Domain.Entities.ProductVariant> Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
    {
        var newProductVariant = await request.ToEntityAsync(_productImageStorageService, _repository);

        _repository.UpdateAsync(newProductVariant);
        await _repository.SaveAsync();

        return newProductVariant;
    }
}