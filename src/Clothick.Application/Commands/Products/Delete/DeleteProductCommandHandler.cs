using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.CustomExceptions;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IBaseRepository<Product> _productRepository;

    public DeleteProductCommandHandler(IBaseRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _productRepository.FindByCondition(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (categoryToDelete is null)
        {
            throw new InvalidId("Product Id doesn't exist");
        }

        _productRepository.DeleteAsync(categoryToDelete);

        await _productRepository.SaveAsync();
    }
}