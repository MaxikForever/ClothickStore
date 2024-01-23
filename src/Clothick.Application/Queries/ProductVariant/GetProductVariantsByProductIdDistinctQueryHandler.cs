using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries;

public class GetProductVariantsByProductIdDistinctQueryHandler : IRequestHandler<GetProductVariantsByProductIdDistinctQuery,IQueryable<ProductVariant>>
{
    private readonly IBaseRepository<ProductVariant> _productVariantsBaseRepository;
    public GetProductVariantsByProductIdDistinctQueryHandler(IBaseRepository<ProductVariant> productVariantsBaseRepository)
    {
        _productVariantsBaseRepository = productVariantsBaseRepository;
    }
    public async Task<IQueryable<ProductVariant>> Handle(GetProductVariantsByProductIdDistinctQuery request, CancellationToken cancellationToken)
    {
        var productVariants = await _productVariantsBaseRepository
            .FindByCondition(pv => pv.ProductID == request.ProductId)
            .Include(pv => pv.Size)
            .Include(pv => pv.Color)
            .Include(pv => pv.Images)
            .ToListAsync(cancellationToken);

        var distinctProductVariants = productVariants
            .GroupBy(pv => pv.Color.Name)
            .Select(g => g.FirstOrDefault())
            .AsQueryable();

        return distinctProductVariants!;
    }

}