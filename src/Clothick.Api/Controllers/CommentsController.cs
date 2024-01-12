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

    /// <summary>
    /// Adds a new comment to a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /products/{productId}/comments
    ///     {
    ///        "content": "Great product!",
    ///        "starRating": 5
    ///     }
    ///
    /// </remarks>
    /// <param name="productId">The ID of the product to comment on</param>
    /// <param name="commentDto">The comment data transfer object</param>
    /// <response code="200">Returns the newly added comment</response>
    /// <response code="400">If the item is null, validation fails, or productId not found</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost("{productId:int}/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

    /// <summary>
    /// Retrieves comments for a specific product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /products/{productId}/comments
    ///
    /// </remarks>
    /// <param name="productId">The ID of the product whose comments are to be retrieved</param>
    /// <response code="200">Returns the comments for the specified product</response>
    /// <response code="404">If no comments are found for the productId</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet("{productId:int}/comments")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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