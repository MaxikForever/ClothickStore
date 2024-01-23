using MediatR;

namespace Clothick.Application.Queries.Size;

public record GetProductSizesCommand(int ProductId) : IRequest<List<string>>;