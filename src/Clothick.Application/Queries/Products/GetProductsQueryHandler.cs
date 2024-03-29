using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.Products;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IList<Product>>
{
    private readonly IBaseRepository<Product> _productRepository;

    public GetProductsQueryHandler(IBaseRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAll()
            .Skip((request.PageNumber -1  ) * request.PageSize)
            .Take(request.PageSize)
            .Include(pr => pr.ProductRatings)
            .ThenInclude(pr => pr.Comments)
            .Include(pr => pr.Category)
            .Include(pr => pr.ProductVariants)
            .ThenInclude(pv => pv.Images)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}