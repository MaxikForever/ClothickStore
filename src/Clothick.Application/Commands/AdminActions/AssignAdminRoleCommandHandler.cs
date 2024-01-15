using Clothick.Domain.Constants;
using Clothick.Domain.CustomExceptions;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Clothick.Application.Commands.AdminActions;

public class AssignAdminRoleCommandHandler : IRequestHandler<AssignAdminRoleCommand, Unit>
{
    private readonly UserManager<User> _userManager;

    public AssignAdminRoleCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(AssignAdminRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (user == null)
        {
            throw new InvalidUserId($"User with this Id {request.UserId} wasn't found");
        }

        var result = await _userManager.AddToRoleAsync(user, RolesConstants.Admin);

        return Unit.Value;
    }
}