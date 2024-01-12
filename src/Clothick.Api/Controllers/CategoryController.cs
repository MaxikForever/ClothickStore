using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Categories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clothick.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IValidatorFactory _validatorFactory;
    private readonly IMediator _mediator;

    public CategoryController(IValidatorFactory validatorFactory, IMediator mediator)
    {
        _validatorFactory = validatorFactory;
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Category
    ///     {
    ///        "categoryName": "TShirt"
    ///     }
    ///
    /// </remarks>
    /// <param name="categoryDto">DTO for creating a category</param>
    /// <response code="200">Returns the newly created category name</response>
    /// <response code="400">If the item is null or validation fails</response>
    /// <response code="401">If user is Unauthorized</response>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CreateCategoryDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
    {
        var validator = _validatorFactory.GetValidator<CreateCategoryDto>();
        var validationResult = await validator.ValidateAsync(categoryDto);

        if (!validationResult.IsValid)

        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var result = await _mediator.Send(new AddCategoryCommand(categoryDto.CategoryName));

        return Ok(new { Name = result });
    }
}