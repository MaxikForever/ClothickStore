using Clothick.Application.Commands.UserRegistrationCommands;

namespace Clothick.Api.Extensions;

public static class MediatorExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(UserRegistrationCommand).Assembly); });
    }
}