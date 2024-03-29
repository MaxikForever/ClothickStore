using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Sizes;

public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand, string>
{
    private readonly IProductVariantService _productVariantService;
    private readonly IBaseRepository<Size> _sizeBaseRepository;

    public CreateSizeCommandHandler(IBaseRepository<Size> sizeBaseRepository,
        IProductVariantService productVariantService)
    {
        _sizeBaseRepository = sizeBaseRepository;
        _productVariantService = productVariantService;
    }

    public async Task<string> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
    {
        var newSize = new Size { Name = request.SizeName.ToUpper() };

        await _sizeBaseRepository.CreateAsync(newSize);
        await _sizeBaseRepository.SaveAsync();

        _productVariantService.UpdateCacheWithNewId(CacheKeyConstants.SizeIds, newSize.Id);
        _productVariantService.UpdateCacheNames(CacheKeyConstants.SizeNames, newSize.Name);

        return newSize.Name;
    }
}