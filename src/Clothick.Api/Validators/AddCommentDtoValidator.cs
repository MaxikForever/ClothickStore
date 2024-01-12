using Clothick.Api.DTO;
using FluentValidation;

namespace Clothick.Api.Validators;

public class AddCommentDtoValidator : AbstractValidator<AddCommentDto>
{
    public AddCommentDtoValidator()
    {
        RuleFor(x => x.StarRating)
            .NotEmpty().WithMessage("Rating can't be empty ")
            .GreaterThanOrEqualTo(0).WithMessage("Rating must be non-negative")
            .LessThanOrEqualTo(5).WithMessage("Rating must be at most 5");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content can't be empty ");
    }
}