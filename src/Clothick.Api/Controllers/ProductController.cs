using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;

    public ProductController(IMediator mediator, IValidatorFactory validatorFactory)
    {
        _mediator = mediator;
        _validatorFactory = validatorFactory;
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductUploadDto productDto)
    {
        var validator = _validatorFactory.GetValidator<ProductUploadDto>();
        var validationResult = await validator.ValidateAsync(productDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.ErrorCode, e.PropertyName, e.ErrorMessage }));
        }

        var request = productDto.ToCommand();

        var product = await _mediator.Send(request);

        var result = product.ToDto();

        return Ok(result);
    }
}