using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.Comment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Domain.Entities.Comment>
{
    private readonly IUserInfoService _userInfoService;
    private readonly IBaseRepository<Domain.Entities.Comment> _commentRepository;
    private readonly IProductRatingService _productRatingService;

    public AddCommentCommandHandler(IUserInfoService userInfoService,
        IBaseRepository<Domain.Entities.Comment> commentRepository, IProductRatingService productRatingService)
    {
        _userInfoService = userInfoService;
        _commentRepository = commentRepository;
        _productRatingService = productRatingService;
    }

    public async Task<Domain.Entities.Comment> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var productRatingId = await _productRatingService.GetProductRatingIdByProductIdAsync(request.ProductId);

        var newComment = request.ToEntity(productRatingId, _userInfoService.GetUserId()!);

        _commentRepository.CreateAsync(newComment);

        await _productRatingService.UpdateProductRatingAsync(productRatingId, newComment.StarRating);

        await _commentRepository.SaveAsync();


        return newComment;
    }
}