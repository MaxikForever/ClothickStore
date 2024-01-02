using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductUploadDto productDto)
    {
        var request = productDto.ToCommand();

        var product = await _mediator.Send(request);

        var result = product.ToDto();

        return Ok(result);
    }
}