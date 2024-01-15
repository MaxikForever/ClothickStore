using Clothick.Application.Commands.AdminActions;
using Clothick.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = RolesConstants.Admin)]
public class AdminActionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminActionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AssignAdminRole([FromForm] AssignAdminRoleCommand request)
    {
        await _mediator.Send(request);

        return Ok(new { StatusCode = StatusCodes.Status200OK, Message = "Admin role assigned successfully" });
    }
}