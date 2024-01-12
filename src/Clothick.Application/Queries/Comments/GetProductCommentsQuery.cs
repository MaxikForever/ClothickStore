using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries.Comments;

public record GetProductCommentsQuery(int ProductId) : IRequest<List<Comment>>;