using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRegistrationController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRegistrationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Post(UserRegistrationDto userDTo)
    {
        var newUser = userDTo.ToCommand();

        var result = await _mediator.Send(newUser);

        if (result.Succeeded)
        {
            return Ok(new
                { Code = StatusCodes.Status200OK, Message = "New Account has been Successfully Registered " });
        }

        return BadRequest(result.Errors);
    }
}