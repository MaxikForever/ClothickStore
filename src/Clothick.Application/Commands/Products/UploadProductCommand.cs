using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products;

public record UploadProductCommand
(
    string BrandName,
    string Title,
    string Description,
    decimal Price,
    int CategoryId
) : IRequest<Product>;