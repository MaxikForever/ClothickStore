using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Commands.Order;
using Clothick.Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public OrderController(IMediator mediator, IValidatorFactory validatorFactory)
    {
        _mediator = mediator;
        _validatorFactory = validatorFactory;
    }

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /CreateOrder
    /// {
    ///   "status": "Shipped",
    ///   "quantity": 10,
    ///   "customerId": 123,
    ///   "productId": 456,
    ///   "price": 50.0
    /// }
    /// </remarks>
    /// <param name="orderDto">DTO for creating an order</param>
    /// <response code="200">Returns the newly created order</response>
    /// <response code="400">If the order is not valid</response>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CreateOrderDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateOrder([FromForm] CreateOrderDto orderDto)
    {
        var validator = _validatorFactory.GetValidator<CreateOrderDto>();
        var validationResult = await validator.ValidateAsync(orderDto);


        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));


        var res = await _mediator.Send(new CreateOrderCommand(orderDto.Status, orderDto.Quantity, orderDto.CustomerId,
            orderDto.ProductVariantId, orderDto.Price));


        var newOrder = res.ToDto();

        return Ok(newOrder);
    }



}