using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.GetAll;

public class GetAllProductVariantsQueryHandler : IRequestHandler<GetAllProductVariantsQuery, IQueryable<ProductVariant>>
{
    private readonly IBaseRepository<ProductVariant> _productVariantsRepository;

    public GetAllProductVariantsQueryHandler(IBaseRepository<ProductVariant> productVariantsRepository)
    {
        _productVariantsRepository = productVariantsRepository;
    }

    public Task<IQueryable<ProductVariant>> Handle(GetAllProductVariantsQuery request,
        CancellationToken cancellationToken)
    {
        var productVariantsList =
            _productVariantsRepository.GetAll()
                .Include(pv => pv.Size)
                .Include(pv => pv.Color)
                .Include(pv => pv.Images)
                .AsQueryable();

        return Task.FromResult(productVariantsList);
    }
}