using Clothick.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Clothick.Application.Commands.UserRegistrationCommands;

public record UserRegistrationCommand
    (string FirstName, string LastName, string Email, string Password, string UserName) : IRequest<IdentityResult>;