using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.Comments;

public class GetProductCommentsQueryHandler : IRequestHandler<GetProductCommentsQuery, List<Comment>>
{
    private readonly IBaseRepository<Comment> _commentsRepository;
    private readonly IProductRatingService _productRatingService;

    public GetProductCommentsQueryHandler(IProductRatingService productRatingService,
        IBaseRepository<Comment> commentsRepository)
    {
        _productRatingService = productRatingService;
        _commentsRepository = commentsRepository;
    }

    public async Task<List<Comment>> Handle(GetProductCommentsQuery request, CancellationToken cancellationToken)
    {
        var productRatingId = await _productRatingService.GetProductRatingIdByProductIdAsync(request.ProductId);

        var comments = await _commentsRepository.FindByCondition(c => c.ProductRatingId == productRatingId)
            .Select(c => c).ToListAsync(cancellationToken);

        return comments;
    }
}