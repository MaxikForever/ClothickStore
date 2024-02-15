using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Commands.ProductVariant.Delete;
using Clothick.Application.Queries;
using Clothick.Application.Queries.GetAll;
using Clothick.Domain.Constants;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("products/")]
public class ProductVariantsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public ProductVariantsController(IValidatorFactory validatorFactory, IMediator mediator)
    {
        _validatorFactory = validatorFactory;
        _mediator = mediator;
    }

    /// <summary>
    ///     Retrieves variants for a specific product.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /products/{productId}/variants
    /// </remarks>
    /// <param name="productId">The ID of the product whose variants are to be retrieved</param>
    /// <response code="200">Returns the product variants for the specified product</response>
    /// <response code="404">If no product variants are found for the productId</response>
    [HttpGet("{productId:int}/variants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetProductVariants(int productId, [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 20)
    {
        var query = new GetProductVariantsByProductIdQuery(productId, pageNumber, pageSize);

        var mediatorResult = await _mediator.Send(query);

        var result = mediatorResult.ToDtoList();

        return result.Any() ? Ok(result) : NotFound();
    }


    /// <summary>
    ///     Adds new variants to a product.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /products/{productId}/variants
    ///     {
    ///     "sizeId": 1,
    ///     "colorId": 2,
    ///     "stock": 100,
    ///     "discountedPrice": 15.99,
    ///     "SKU": "SKU12345"
    ///     }
    /// </remarks>
    /// <param name="productId">The ID of the product to which variants are added</param>
    /// <param name="productDto">DTO for uploading product variants</param>
    /// <response code="200">Returns the newly added product variant</response>
    /// <response code="400">If the item is null, validation fails</response>
    /// <response code="404">If the product ID doesn't exist</response>
    /// <response code="401">If the user is unauthorized</response>
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpPost("{productId:int}/variants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> AddProductVariants(int productId, [FromForm] UploadProductVariantDto productDto)
    {
        var validator = _validatorFactory.GetValidator<UploadProductVariantDto>();
        var validationResult = await validator.ValidateAsync(productDto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));

        var mediatorResult = await _mediator.Send(productDto.ToCommand(productId));

        if (mediatorResult.Id == 0) return NotFound("Product Id doesn't exist");

        var result = mediatorResult.ToDto();


        return Ok(result);
    }

    /// <summary>
    /// Updates a product variant.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PATCH /variants/{productVariantId}
    /// {
    ///   // Include fields to update in the request body
    /// }
    /// </remarks>
    /// <param name="productVariantId">The ID of the product variant to update</param>
    /// <param name="productDto">DTO containing the updated information for the product variant</param>
    /// <response code="200">Returns the updated product variant</response>
    /// <response code="400">If the request is invalid</response>
    /// <response code="401">If the user is unauthorized</response>
    /// <response code="404">If the product ID doesn't exist</response>
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpPatch("variants/{productVariantId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdateProductVariants(int productVariantId,
        [FromForm] UpdateProductVariantDto productDto)
    {
        var mediatorResult = await _mediator.Send(productDto.ToCommand(productVariantId));

        if (mediatorResult.Id == 0) return NotFound("Product Id doesn't exist");

        var result = mediatorResult.ToDto();

        return Ok(result);
    }

    /// <summary>
    ///     Retrieves distinct color variants for a specific product.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /products/{productId}/variants
    /// </remarks>
    /// <param name="productId">The ID of the product whose variants are to be retrieved</param>
    /// <response code="200">Returns the product variants for the specified product</response>
    /// <response code="404">If no product variants are found for the productId</response>
    [HttpGet("{productId:int}/variants/distinct")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetProductVariantsDistinct(int productId)
    {
        var query = new GetProductVariantsByProductIdDistinctQuery(productId);

        var mediatorResult = await _mediator.Send(query);

        var result = mediatorResult.ToDtoList();

        return result.Any() ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Retrieves all product variants.
    /// </summary>
    /// <returns>A list of all product variants</returns>
    /// <response code="200">Returns a list of all product variants</response>
    [HttpGet("variants")]
    public async Task<IActionResult> GetAllProductVariants()
    {
        var productVariants = await _mediator.Send(new GetAllProductVariantsQuery());

        return Ok(productVariants.ToDtoList());
    }



    /// <summary>
    /// Deletes a product variant by ID.
    /// </summary>
    /// <param name="id">ID of the product variant to delete</param>
    /// <returns>Object indicating the result of deletion</returns>
    /// <response code="200">Successful deletion</response>
    /// <response code="400">Invalid ID provided</response>
    /// <response code="401">If the user is unauthorized</response>
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpDelete("variants/delete/{id:int}")]
    public async Task<IActionResult> DeleteProductVariant(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        await _mediator.Send(new DeleteProductVariantCommand(id));

        return Ok(new {Result = "Item was successfully deleted"});
    }



}