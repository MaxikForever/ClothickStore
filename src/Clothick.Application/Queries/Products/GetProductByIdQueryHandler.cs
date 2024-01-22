using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.CustomExceptions;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.Products;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IBaseRepository<Product> _productRepository;

    public GetProductByIdQueryHandler(IBaseRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByCondition(pr => pr.Id == request.ProductId)
            .Include(pr => pr.ProductRatings)
            .ThenInclude(pr => pr.Comments)
            .Include(pr => pr.Category)
            .Include(pr => pr.ProductVariants)
            .ThenInclude(pv => pv.Images)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (product is null)
        {
            throw new InvalidProductId($"A product with Id: {request.ProductId} was not found");
        }

        return product!;
    }

}
