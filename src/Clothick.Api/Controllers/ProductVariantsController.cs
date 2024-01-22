using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Queries;
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
    public async Task<ActionResult> GetProductVariants(int productId)
    {
        var query = new GetProductVariantsByProductIdQuery(productId);

        var mediatorResult = await _mediator.Send(query);

        var result = await mediatorResult.ToDtoAsync();

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


    [Authorize(Roles = RolesConstants.Admin)]
    [HttpPatch("variants/{productVariantId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdateProductVariants(int productVariantId, [FromForm] UpdateProductVariantDto productDto)
    {
        var mediatorResult = await _mediator.Send(productDto.ToCommand(productVariantId));

        if (mediatorResult.Id == 0) return NotFound("Product Id doesn't exist");

        var result = mediatorResult.ToDto();

        return Ok(result);
    }


}