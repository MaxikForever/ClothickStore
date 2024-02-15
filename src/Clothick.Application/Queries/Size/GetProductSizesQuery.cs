using MediatR;

namespace Clothick.Application.Queries.Size;

public record GetProductSizesQuery(int ProductId) : IRequest<List<string>>;