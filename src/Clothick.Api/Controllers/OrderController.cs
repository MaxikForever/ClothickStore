using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Commands.Order;
using Clothick.Application.Commands.Order.CloseOrder;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using Clothick.Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    /// <summary>
    /// Marks an order as delivered.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /orders/{orderId}/deliver
    /// </remarks>
    /// <param name="orderId">The ID of the order to mark as delivered</param>
    /// <response code="200">Returns a success message indicating that the order was marked as delivered</response>
    /// <response code="404">If the order with the specified ID is not found</response>
    [HttpPost("{orderId}/deliver")]
    public async Task<IActionResult> MarkOrderAsDelivered(int orderId)
    {
        var orderResult = await _mediator.Send(new CloseOrderCommand(orderId));

        return Ok(new {Result = orderResult});
    }
}