using Clothick.Api.Constants;
using Clothick.Api.DTO;
using FluentValidation;

namespace Clothick.Api.Validators;

public class UserLoginDtoValidator: AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.UserNameRequired)
            .Length(3, 30).WithMessage(AuthentificationValidationErrorMessages.UserNameInvalidLength)
            .Matches("^[a-zA-Z0-9\\s\\-\\']+$")
            .WithMessage(AuthentificationValidationErrorMessages.UserNameInvalidCharacters);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.PasswordRequired)
            .Length(4, 30).WithMessage(AuthentificationValidationErrorMessages.PasswordInvalidLength)
            .Matches("[A-Z]").WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresUppercase)
            .Matches("[a-z]").WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresLowercase)
            .Matches("[0-9]").WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresDigit)
            .Matches("[!@#$%^&*(),.?\":{}|<>]")
            .WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresSpecialCharacter)
            .NotEqual(x => x.UserName).WithMessage(AuthentificationValidationErrorMessages.PasswordCannotBeUserName);
    }
}