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

    /// <summary>
    /// Assigns the admin role to a user.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /adminactions
    /// {
    ///   "userId": "123"
    /// }
    /// </remarks>
    /// <param name="request">Command containing the user ID to assign admin role</param>
    /// <response code="200">Admin role assigned successfully</response>
    [HttpPost]
    public async Task<IActionResult> AssignAdminRole([FromForm] AssignAdminRoleCommand request)
    {
        await _mediator.Send(request);

        return Ok(new { StatusCode = StatusCodes.Status200OK, Message = "Admin role assigned successfully" });
    }
}