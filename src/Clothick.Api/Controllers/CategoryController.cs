using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Categories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IValidatorFactory _validatorFactory;
    private readonly IMediator _mediator;

    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
    {

        var validator = _validatorFactory.GetValidator<CreateCategoryDto>();
        var validationResult = await validator.ValidateAsync(categoryDto);

        if (!validationResult.IsValid)

        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var result = _mediator.Send(new AddCategoryCommand(categoryDto.CategoryName));

        return Ok(new { Name = result });
    }
}