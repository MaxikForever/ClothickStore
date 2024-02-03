using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries;

public class GetProductVariantsByProductIdQueryHandler : IRequestHandler<GetProductVariantsByProductIdQuery,
    IQueryable<ProductVariant>>
{
    private readonly IBaseRepository<ProductVariant> _productVariantsBaseRepository;

    public GetProductVariantsByProductIdQueryHandler(IBaseRepository<ProductVariant> productVariantsBaseRepository)
    {
        _productVariantsBaseRepository = productVariantsBaseRepository;
    }

    public Task<IQueryable<ProductVariant>> Handle(GetProductVariantsByProductIdQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult
        (_productVariantsBaseRepository
            .FindByCondition(pv => pv.ProductID == request.ProductId)
            .Skip((request.PageNumber -1  ) * request.PageSize)
            .Take(request.PageSize)
            .Include(pv => pv.Size)
            .Include(pv => pv.Color)
            .Include(pv => pv.Images)
            .AsQueryable()
        );
    }
}