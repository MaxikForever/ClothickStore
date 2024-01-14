using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.ProductVariant;

public class
    AddProductVariantsCommandHandler : IRequestHandler<UploadProductVariantCommand, Domain.Entities.ProductVariant>
{
    private readonly IBaseRepository<Domain.Entities.ProductVariant> _repository;
    private readonly IProductImageStorageService _productImageStorageService;

    public AddProductVariantsCommandHandler(IBaseRepository<Domain.Entities.ProductVariant> repository,
        IProductImageStorageService productImageStorageService)
    {
        _repository = repository;
        _productImageStorageService = productImageStorageService;
    }

    public async Task<Domain.Entities.ProductVariant> Handle(UploadProductVariantCommand request,
        CancellationToken cancellationToken)
    {
        var newProductVariant = await request.ToEntity(_productImageStorageService);

        _repository.CreateAsync(newProductVariant);

        await _repository.SaveAsync();

        var result = await _repository.FindByCondition(pv => pv.Id == newProductVariant.Id)
            .Include(pv => pv.Size)
            .Include(pv => pv.Color)
            .Include(pv => pv.Images)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return result!;
    }
}