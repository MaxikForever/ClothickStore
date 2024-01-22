using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries.Products;

public record GetProductByIdQuery(int ProductId) : IRequest<Product>;