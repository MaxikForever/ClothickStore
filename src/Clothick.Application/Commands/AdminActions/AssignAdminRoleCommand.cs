using MediatR;

namespace Clothick.Application.Commands.AdminActions;

public record AssignAdminRoleCommand(Guid UserId) : IRequest<Unit>;