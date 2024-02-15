using MediatR;

namespace Clothick.Application.Queries.Size.GetAll;

public record GetAllSizesQuery : IRequest<List<Domain.Entities.Size>>;