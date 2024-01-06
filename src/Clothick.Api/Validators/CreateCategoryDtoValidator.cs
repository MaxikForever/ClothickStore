using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using FluentValidation;

namespace Clothick.Api.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator(IUniqueService<Category> uniqueService)
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Category name is required.")
            .Length(2, 100).WithMessage("Category name must be between 2 and 100 characters.")
            .MustAsync(async (categoryName, _) =>
                await uniqueService.IsNameUniqueAsync(CacheKeyConstants.CategoryNames, categoryName))
            .WithMessage("Category name must be Unique");
    }
}