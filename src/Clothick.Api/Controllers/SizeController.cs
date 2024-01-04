using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Sizes;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SizeController : ControllerBase
{
    private readonly IValidatorFactory _validatorFactory;
    private readonly IMediator _mediator;

    public SizeController(IValidatorFactory validatorFactory, IMediator mediator)
    {
        _validatorFactory = validatorFactory;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateSize([FromBody] CreateSizeDto sizeNameDto)
    {
        var validator = _validatorFactory.GetValidator<CreateSizeDto>();
        var validationResult = await validator.ValidateAsync(sizeNameDto);

        if (!validationResult.IsValid)

        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var result = await _mediator.Send(new CreateSizeCommand(sizeNameDto.SizeName));

        return Ok(new {Name = result});
    }
}