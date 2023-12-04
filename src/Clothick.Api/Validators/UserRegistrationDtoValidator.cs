using Clothick.Api.Constants;
using Clothick.Api.DTO;
using FluentValidation;

namespace Clothick.Api.Validators;

public class UserRegistrationDtoValidator : AbstractValidator<UserRegistrationDto>
{
    public UserRegistrationDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .Length(3, 30).WithMessage(AuthentificationValidationErrorMessages.FirstNameInvalidLength)
            .Matches("^[a-zA-Z\\s\\-\\']+$")
            .WithMessage(AuthentificationValidationErrorMessages.FirstNameInvalidCharacters);

        RuleFor(x => x.LastName)
            .Length(3, 30).WithMessage(AuthentificationValidationErrorMessages.LastNameInvalidLength)
            .Matches("^[a-zA-Z\\s\\-\\']+$")
            .WithMessage(AuthentificationValidationErrorMessages.LastNameInvalidCharacters);

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.UserNameRequired)
            .Length(3, 30).WithMessage(AuthentificationValidationErrorMessages.UserNameInvalidLength)
            .Matches("^[a-zA-Z0-9\\s\\-\\']+$")
            .WithMessage(AuthentificationValidationErrorMessages.UserNameInvalidCharacters);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.EmailRequired)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage(AuthentificationValidationErrorMessages.EmailInvalidFormat);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.PasswordRequired)
            .Length(4, 30).WithMessage(AuthentificationValidationErrorMessages.PasswordInvalidLength)
            .Matches("[A-Z]").WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresUppercase)
            .Matches("[a-z]").WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresLowercase)
            .Matches("[0-9]").WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresDigit)
            .Matches("[!@#$%^&*(),.?\":{}|<>]")
            .WithMessage(AuthentificationValidationErrorMessages.PasswordRequiresSpecialCharacter)
            .NotEqual(x => x.UserName).WithMessage(AuthentificationValidationErrorMessages.PasswordCannotBeUserName);

        RuleFor(x => x.PassowrdConfirmation)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.PasswordConfirmationRequired)
            .Equal(x => x.Password).WithMessage(AuthentificationValidationErrorMessages.PasswordConfirmationMustMatch);
    }
}