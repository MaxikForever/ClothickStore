using Clothick.Application.Commands.UserRegistrationCommands.Login;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Clothick.Application.Commands.UserRegistrationCommands;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string>
{
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;

    public UserLoginCommandHandler(SignInManager<User> signInManager, ITokenService tokenService,
        UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);
        if (!result.Succeeded)
        {
            throw new Exception("User login failed");
        }

        var token = await _tokenService.GenerateTokenAsync(await _userManager.FindByNameAsync(request.Username));

        return token;
    }
}