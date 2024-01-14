using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
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

    /// <summary>
    ///     Registers a new user.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /UserRegistration/register
    ///     {
    ///     "firstName": "John",
    ///     "lastName": "Doe",
    ///     "userName": "john.doe",
    ///     "email": "johndoe@example.com",
    ///     "password": "YourSecurePassword123!",
    ///     "passwordConfirmation": "YourSecurePassword123!"
    ///     }
    /// </remarks>
    /// <param name="registrationDto">DTO for user registration</param>
    /// <response code="200">If the user is successfully registered</response>
    /// <response code="400">If the request is invalid or validation fails</response>
    /// <response code="500">If an internal server error occurs</response>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(UserRegistrationDto registrationDto)
    {
        var validator = _validatorFactory.GetValidator<UserRegistrationDto>();
        var validationResult = await validator.ValidateAsync(registrationDto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));

        var newUser = registrationDto.ToCommand();

        var result = await _mediator.Send(newUser);

        if (result.Succeeded)
            return Ok(new
                { Code = StatusCodes.Status200OK, Message = "New Account has been Successfully Registered" });

        return BadRequest(result.Errors);
    }

    /// <summary>
    ///     Logs in a registered user.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /UserRegistration/login
    ///     {
    ///     "userName": "john.doe",
    ///     "password": "YourSecurePassword123!"
    ///     }
    /// </remarks>
    /// <param name="loginDto">DTO for user login</param>
    /// <response code="200">If the login is successful</response>
    /// <response code="400">If the login request is invalid or validation fails</response>
    /// <response code="500">If an internal server error occurs</response>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Login(UserLoginDto loginDto)
    {
        var validator = _validatorFactory.GetValidator<UserLoginDto>();
        var validationResult = validator.Validate(loginDto);
        if (!validationResult.IsValid)
            return Task.FromResult<IActionResult>(
                BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage })));

        var loginCommand = loginDto.ToCommand();

        var token = _mediator.Send(loginCommand);

        return Task.FromResult<IActionResult>(Ok(new { JwtToken = token }));
    }
}