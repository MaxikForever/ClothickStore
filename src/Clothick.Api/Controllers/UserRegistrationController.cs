using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Api.Validators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRegistrationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public UserRegistrationController(IMediator mediator, IValidatorFactory validatorFactory)
    {
        _mediator = mediator;
        _validatorFactory = validatorFactory;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Post(UserRegistrationDto userDTo)
    {
        var validator = _validatorFactory.GetValidator<UserRegistrationDto>();
        var validationResult = await validator.ValidateAsync(userDTo);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var newUser = userDTo.ToCommand();

        var result = await _mediator.Send(newUser);

        if (result.Succeeded)
        {
            return Ok(new
                { Code = StatusCodes.Status200OK, Message = "New Account has been Successfully Registered " });
        }

        return BadRequest(result.Errors);
    }

    [HttpGet("GetUser")] public IActionResult GetMyUser()
    {
        return Ok(new { Name = "Max", SecondName = "Cbum" });
    } 
}