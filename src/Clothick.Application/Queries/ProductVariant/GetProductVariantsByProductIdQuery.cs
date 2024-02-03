using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries;

public record GetProductVariantsByProductIdQuery
    (int ProductId, int PageNumber, int PageSize) : IRequest<IQueryable<ProductVariant>>;