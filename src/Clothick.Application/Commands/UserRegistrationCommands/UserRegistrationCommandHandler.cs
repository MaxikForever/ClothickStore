using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Clothick.Application.Commands.UserRegistrationCommands;

public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, IdentityResult>
{
    private readonly UserManager<User> _userManager;

    public UserRegistrationCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        await _userManager.CreateAsync(user, request.Password);

        return IdentityResult.Success;
    }
}