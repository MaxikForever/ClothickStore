using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Sizes;
using Clothick.Application.Queries.Size;
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


    [HttpGet("product/{productId:int}/productvariant/[controller]")]
    public async Task<ActionResult> GetSizeByProductId(int productId)
    {
        var productSizes = await _mediator.Send(new GetProductSizesCommand(productId));

        if (!productSizes.Any())
        {
            return BadRequest(new
                { ErrorCode = 404, PropertyName = "ProductId", ErrorMessage = "Product Id doesn't exist" });
        }

        return Ok(productSizes);
    }
}