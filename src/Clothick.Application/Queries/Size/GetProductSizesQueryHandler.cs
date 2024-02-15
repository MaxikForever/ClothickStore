using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.Size;

public class GetProductSizesQueryHandler : IRequestHandler< GetProductSizesQuery,List<string>>
{
    private readonly IBaseRepository<ProductVariant> _productVariantRepository;

    public GetProductSizesQueryHandler(IBaseRepository<ProductVariant> productVariantRepository)
    {
        _productVariantRepository = productVariantRepository;
    }

    public async Task<List<string>> Handle(GetProductSizesQuery request, CancellationToken cancellationToken)
    {
        var productVariants = await _productVariantRepository.FindByCondition(pv => pv.ProductID == request.ProductId)
            .Include(pv => pv.Size).ToListAsync(cancellationToken: cancellationToken);

        var sizes =  productVariants.Select(pv => pv.Size.Name).Distinct().ToList();

        return sizes;
    }
}