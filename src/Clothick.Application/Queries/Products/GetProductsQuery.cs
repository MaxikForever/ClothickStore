using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries.Products;

public record GetProductsQuery() : IRequest<IList<Product>>;