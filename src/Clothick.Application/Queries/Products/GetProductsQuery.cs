using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries.Products;

public record GetProductsQuery(int PageNumber, int PageSize) : IRequest<IList<Product>>;