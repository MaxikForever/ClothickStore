using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
}