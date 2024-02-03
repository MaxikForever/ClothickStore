using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Queries.Products;
using Clothick.Domain.Constants;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]/")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public ProductsController(IMediator mediator, IValidatorFactory validatorFactory)
    {
        _mediator = mediator;
        _validatorFactory = validatorFactory;
    }


    /// <summary>
    ///     Creates a new product.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /Product
    ///     {
    ///     "name": "T-Shirt",
    ///     "description": "A plain t-shirt",
    ///     "price": 19.99,
    ///     "categoryId": 1,
    ///     // Other properties
    ///     }
    /// </remarks>
    /// <param name="productDto">DTO for creating a product</param>
    /// <response code="200">Returns the newly created product</response>
    /// <response code="400">If the item is null, validation fails</response>
    /// <response code="401">If the user is unauthorized</response>
    [Authorize(Roles = RolesConstants.Admin)]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateProduct(ProductUploadDto productDto)
    {
        var validator = _validatorFactory.GetValidator<ProductUploadDto>();
        var validationResult = await validator.ValidateAsync(productDto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));

        var request = productDto.ToCommand();

        var product = await _mediator.Send(request);

        var result = product.ToDto();

        return Ok(result);
    }


    /// <summary>
    ///     Retrieves a list of products.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /Product
    ///
    ///     It returns a list of all products.
    /// </remarks>
    /// <response code="200">Returns the list of products</response>
    /// <response code="400">If the request is badly formed</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProducts([FromQuery] int pageNumber = 1, [FromQuery]int pageSize = 20)
    {
        var products = await _mediator.Send(new GetProductsQuery(pageNumber, pageSize));

        if (!products.Any())
            return BadRequest(new
            {
                ErrorCode = StatusCodes.Status400BadRequest, PropertyName = "Products",
                ErrorMessage = "Products retrieval failed."
            });

        return Ok(products.ToDtoList());
    }


    /// <summary>
    ///     Retrieves a list of products.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /Product
    ///
    ///     It returns a list of all products.
    /// </remarks>
    /// <response code="200">Returns the list of products</response>
    /// <response code="400">If the request is badly formed</response>
    [HttpGet("{productId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var products = await _mediator.Send(new GetProductByIdQuery(productId));

        return Ok(products.ToDto());
    }
}