using MediatR;

namespace Clothick.Application.Commands.ProductVariant.Delete;

public record DeleteProductVariantCommand(int Id) : IRequest;