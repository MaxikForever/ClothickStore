using MediatR;

namespace Clothick.Application.Commands.Comment;

public record AddCommentCommand(string Content, decimal StarRating, int ProductId) : IRequest<Domain.Entities.Comment>;