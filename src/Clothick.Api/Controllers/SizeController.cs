using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Commands.UserRegistrationCommands.Sizes;
using Clothick.Application.Commands.UserRegistrationCommands.Sizes.Delete;
using Clothick.Application.Queries.Size;
using Clothick.Application.Queries.Size.GetAll;
using Clothick.Domain.Constants;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
public class SizeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public SizeController(IValidatorFactory validatorFactory, IMediator mediator)
    {
        _validatorFactory = validatorFactory;
        _mediator = mediator;
    }

    /// <summary>
    ///     Creates a new size.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /Size
    ///     {
    ///     "sizeName": "Medium"
    ///     }
    /// </remarks>
    /// <param name="sizeNameDto">DTO for creating a size</param>
    /// <response code="200">Returns the newly created size name</response>
    /// <response code="400">If the item is null or validation fails</response>
    /// <response code="401">If the user is unauthorized</response>
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpPost("product/productvariant/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> CreateSize([FromBody] CreateSizeDto sizeNameDto)
    {
        var validator = _validatorFactory.GetValidator<CreateSizeDto>();
        var validationResult = await validator.ValidateAsync(sizeNameDto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));

        var result = await _mediator.Send(new CreateSizeCommand(sizeNameDto.SizeName));

        return Ok(new { Name = result });
    }

    /// <summary>
    /// Retrieves the sizes of a product by its ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /products/{productId}/productvariant/sizes
    /// </remarks>
    /// <param name="productId">The ID of the product</param>
    /// <response code="200">Returns the sizes of the product</response>
    /// <response code="400">If the product ID doesn't exist</response>
    [HttpGet("product/{productId:int}/productvariant/[controller]")]
    public async Task<ActionResult> GetSizeByProductId(int productId)
    {
        var productSizes = await _mediator.Send(new GetProductSizesQuery(productId));

        if (!productSizes.Any())
        {
            return BadRequest(new
                { ErrorCode = 404, PropertyName = "ProductId", ErrorMessage = "Product Id doesn't exist" });
        }

        return Ok(productSizes);
    }

    /// <summary>
    /// Retrieves all sizes.
    /// </summary>
    /// <returns>A list of all sizes</returns>
    /// <response code="200">Returns a list of all sizes</response>
    [HttpGet("product/productvariant/[controller]")]
    public async Task<IActionResult> GetAllSizes()
    {
        var sizes = await _mediator.Send(new GetAllSizesQuery());

        return Ok(sizes.ToDtoList());
    }


    /// <summary>
    /// Deletes a size by ID.
    /// </summary>
    /// <param name="id">ID of the size to delete</param>
    /// <returns>Object indicating the result of deletion</returns>
    /// <response code="200">Successful deletion</response>
    /// <response code="400">Invalid ID provided</response>
    /// <response code="401">If the user is unauthorized</response>
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpDelete("product/productvariant/size/delete/{id:int}")]
    public async Task<IActionResult> DeleteSize(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        await _mediator.Send(new DeleteSizeCommand(id));

        return Ok(new {Result = "Item was successfully deleted"});
    }


}