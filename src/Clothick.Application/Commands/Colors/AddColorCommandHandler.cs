using System.Globalization;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.UserRegistrationCommands.Colors;

public class AddColorCommandHandler : IRequestHandler<AddColorCommand, string>
{
    private readonly IBaseRepository<Color> _colorBaseRepository;
    private readonly TextInfo _textInfo;
    private readonly IProductVariantService _productVariantService;

    public AddColorCommandHandler(IBaseRepository<Color> colorBaseRepository,
        IProductVariantService productVariantService)
    {
        _colorBaseRepository = colorBaseRepository;
        _productVariantService = productVariantService;
        _textInfo = CultureInfo.CurrentCulture.TextInfo;
    }

    public async Task<string> Handle(AddColorCommand request, CancellationToken cancellationToken)
    {
        var capitalizedColorName = _textInfo.ToTitleCase(request.ColorName);
        var newColor = new Color() { Name = capitalizedColorName };

        await _colorBaseRepository.CreateAsync(newColor);
        await _colorBaseRepository.SaveAsync();

        _productVariantService.UpdateCacheWithNewId(CacheKeyConstants.ColorIds, newColor.Id);
        _productVariantService.UpdateCacheNames(CacheKeyConstants.ColorNames, newColor.Name);

        return newColor.Name;
    }
}