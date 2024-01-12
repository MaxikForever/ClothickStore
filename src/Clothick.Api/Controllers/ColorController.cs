using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Colors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clothick.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ColorController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public ColorController(IMediator mediator, IValidatorFactory validatorFactory)
    {
        _mediator = mediator;
        _validatorFactory = validatorFactory;
    }

    /// <summary>
    /// Creates a new color.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Color
    ///     {
    ///        "colorName": "Red"
    ///     }
    ///
    /// </remarks>
    /// <param name="colorDto">DTO for creating a color</param>
    /// <response code="200">Returns the newly created color name</response>
    /// <response code="400">If the item is null or validation fails</response>
    /// <response code="401">If user is Unauthorized</response>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CreateColorDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> CreateColor([FromBody] CreateColorDto colorDto)
    {
        var validator = _validatorFactory.GetValidator<CreateColorDto>();
        var validationResult = await validator.ValidateAsync(colorDto);

        if (!validationResult.IsValid)

        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var colorName = colorDto.ColorName;

        var result = await _mediator.Send(new AddColorCommand(colorName));

        return Ok(new { Name = result });
    }
}