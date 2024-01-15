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
            .Include(pr => pr.ProductRatings)
            .ThenInclude(pr => pr.Comments)
            .Include(pr => pr.Category)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}