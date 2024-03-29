using Clothick.Application.Extensions;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Clothick.Application.Commands.UserRegistrationCommands;

public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, IdentityResult>
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public UserRegistrationCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();
        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            var userCreation = await _userManager.AddToRoleAsync(user, RolesConstants.User);
            if (userCreation.Succeeded) await _signInManager.SignInAsync(user, false);
        }

        return result;
    }
}