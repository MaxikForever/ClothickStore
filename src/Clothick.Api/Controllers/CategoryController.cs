using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Commands.UserRegistrationCommands.Categories;
using Clothick.Application.Queries.Categories;
using Clothick.Domain.Constants;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clothick.Api.Controllers;

[Authorize]
[ApiController]
[Route("/product/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public CategoryController(IValidatorFactory validatorFactory, IMediator mediator)
    {
        _validatorFactory = validatorFactory;
        _mediator = mediator;
    }

    /// <summary>
    ///     Creates a new category.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /Category
    ///     {
    ///     "categoryName": "TShirt"
    ///     }
    /// </remarks>
    /// <param name="categoryDto">DTO for creating a category</param>
    /// <response code="200">Returns the newly created category name</response>
    /// <response code="400">If the item is null or validation fails</response>
    /// <response code="401">If user is Unauthorized</response>
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CreateCategoryDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
    {
        var validator = _validatorFactory.GetValidator<CreateCategoryDto>();
        var validationResult = await validator.ValidateAsync(categoryDto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));

        var result = await _mediator.Send(new AddCategoryCommand(categoryDto.CategoryName));

        return Ok(new { Name = result });
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Category
    /// </remarks>
    /// <returns>Returns a list of all categories.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery());

        return Ok(categories.ToDtoList());
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /Category/delete/{id}
    /// </remarks>
    /// <param name="id">The ID of the category to delete.</param>
    /// <response code="200">Returns true if the category is successfully deleted.</response>
    /// <response code="400">If the ID is invalid.</response>
    /// &lt;response code="401"&gt;If the user is unauthorized&lt;/response&gt;
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        await _mediator.Send(new DeleteCategoryCommand(id));

        return Ok(new { Result = "Item was successfully deleted" });
    }
}