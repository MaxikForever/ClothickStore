using FluentValidation;

namespace Clothick.Api.Extensions;

public class ValidatorFactory : IValidatorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ValidatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IValidator<T> GetValidator<T>()
    {
        Type validatorType = typeof(IValidator<>).MakeGenericType(typeof(T));
        return _serviceProvider.GetService(validatorType) as IValidator<T>;
    }

    public IValidator GetValidator(Type type)
    {
        var genericType = typeof(IValidator<>).MakeGenericType(type);
        return _serviceProvider.GetService(genericType) as IValidator;
    }
}