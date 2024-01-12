using System.Reflection;
using Clothick.Api.DTO;
using Clothick.Api.Extensions.Mappers;
using Clothick.Application.Queries.Comments;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Api.Controllers;

[Authorize]
[ApiController]
[Route("products/")]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;
    private readonly IBaseRepository<User> _userRepository;

    public CommentsController(IMediator mediator, IValidatorFactory validatorFactory,
        IBaseRepository<User> userRepository)
    {
        _mediator = mediator;
        _validatorFactory = validatorFactory;
        _userRepository = userRepository;
    }

    [HttpPost("{productId:int}/[controller]")]
    public async Task<IActionResult> AddComment(int productId, [FromBody] AddCommentDto commentDto)
    {
        var validator = _validatorFactory.GetValidator<AddCommentDto>();
        var validationResult = await validator.ValidateAsync(commentDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(
                validationResult.Errors.Select(er => new { er.ErrorCode, er.PropertyName, er.ErrorMessage }));
        }


        var newComment = await _mediator.Send(commentDto.ToCommand(productId));

        return newComment.Id != 0
            ? Ok(newComment.ToDto(_userRepository))
            : BadRequest(new
            {
                ErrorCode = StatusCodes.Status400BadRequest, PropertyName = "productId",
                ErrorMessage = "ProductId not found"
            });
    }

    [HttpGet("{productId:int}/comments")]
    public async Task<IActionResult> GetComments(int productId)
    {
        var comments = await _mediator.Send(new GetProductCommentsQuery(productId));

        if (!comments.Any())
        {
            return NotFound(new
            {
                ErrorCode = StatusCodes.Status404NotFound, PropertyName = "productId",
                ErrorMessage = "ProductId not found"
            });
        }

        var result = comments.ToDtoList(_userRepository);

        return Ok(result);
    }
}