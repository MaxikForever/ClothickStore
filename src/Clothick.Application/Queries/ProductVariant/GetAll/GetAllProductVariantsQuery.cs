using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries.GetAll;

public record GetAllProductVariantsQuery(): IRequest<IQueryable<ProductVariant>>;