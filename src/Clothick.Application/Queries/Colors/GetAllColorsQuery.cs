using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries.Colors;

public record GetAllColorsQuery(): IRequest<List<Color>>;