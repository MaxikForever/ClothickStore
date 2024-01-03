using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Colors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

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

    [HttpPost]
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

        return Ok(result);
    }
}