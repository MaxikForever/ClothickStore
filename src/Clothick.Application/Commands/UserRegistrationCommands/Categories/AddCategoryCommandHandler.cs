using System.Globalization;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Categories;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, string>
{
    private readonly IBaseRepository<Category> _categoryBaseRepository;
    private readonly IProductVariantService _productVariantService;
    private readonly TextInfo _textInfo;


    public AddCategoryCommandHandler(IBaseRepository<Category> categoryBaseRepository,
        IProductVariantService productVariantService)
    {
        _categoryBaseRepository = categoryBaseRepository;
        _productVariantService = productVariantService;
        _textInfo = CultureInfo.CurrentCulture.TextInfo;
    }

    public async Task<string> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var capitalizedCategoryName = _textInfo.ToTitleCase(request.CategoryName);
        var newCategory = new Category() { Name = capitalizedCategoryName };

        await _categoryBaseRepository.CreateAsync(newCategory);
        await _categoryBaseRepository.SaveAsync();

        _productVariantService.UpdateCacheWithNewId(CacheKeyConstants.CategoryIds, newCategory.Id);
        _productVariantService.UpdateCacheNames(CacheKeyConstants.CategoryNames, newCategory.Name);

        return newCategory.Name;
    }
}