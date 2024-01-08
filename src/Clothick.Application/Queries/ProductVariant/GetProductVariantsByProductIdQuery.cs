using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries;

public record GetProductVariantsByProductIdQuery(int ProductId) : IRequest<IQueryable<ProductVariant>>;