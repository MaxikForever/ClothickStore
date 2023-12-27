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
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(UserRegistrationDto registrationDto)
    {
        var validator = _validatorFactory.GetValidator<UserRegistrationDto>();
        var validationResult = await validator.ValidateAsync(registrationDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var newUser = registrationDto.ToCommand();

        var result = await _mediator.Send(newUser);

        if (result.Succeeded)
        {
            return Ok(new
                { Code = StatusCodes.Status200OK, Message = "New Account has been Successfully Registered " });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Login(UserLoginDto loginDto)
    {
        var validator = _validatorFactory.GetValidator<UserLoginDto>();
        var validationResult = validator.Validate(loginDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e =>  new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }


    }
}