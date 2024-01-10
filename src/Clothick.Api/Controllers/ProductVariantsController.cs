using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("products/")]
public class ProductVariantsController : ControllerBase
{
    private readonly IValidatorFactory _validatorFactory;
    private readonly IMediator _mediator;

    public ProductVariantsController(IValidatorFactory validatorFactory, IMediator mediator)
    {
        _validatorFactory = validatorFactory;
        _mediator = mediator;
    }

    [HttpGet("{productId:int}/variants")]
    public async Task<ActionResult> GetProductVariants(int productId)
    {
        var query = new GetProductVariantsByProductIdQuery(productId);

        var mediatorResult = await _mediator.Send(query);

        var result = await mediatorResult.ToDtoAsync();

        return result.Any() ? Ok(result) : NotFound();
    }


    [HttpPost("{productId:int}/variants")]
    public async Task<ActionResult> AddProductVariants(int productId, [FromBody] UploadProductVariantDto productDto)
    {
        var validator = _validatorFactory.GetValidator<UploadProductVariantDto>();
        var validationResult = await validator.ValidateAsync(productDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var mediatorResult = await _mediator.Send(productDto.ToCommand(productId));

        if (mediatorResult.Id == 0)
        {
            return NotFound("Product Id doesn't exist");
        }

        var result = mediatorResult.ToDto();


        return Ok(result);
    }
}