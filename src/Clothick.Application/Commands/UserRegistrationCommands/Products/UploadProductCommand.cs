using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products;

public record UploadProductCommand(Product Product) : IRequest<Product>
{
}