using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries;

public record GetProductVariantsByProductIdDistinctQuery(int ProductId) : IRequest<IQueryable<ProductVariant>>;