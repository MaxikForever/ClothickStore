using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.CustomExceptions;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.UserRegistrationCommands.Categories;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IBaseRepository<Category> _categoryRepository;

    public DeleteCategoryCommandHandler(IBaseRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _categoryRepository.FindByCondition(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (categoryToDelete is null)
        {
            throw new InvalidId("Category Id doesn't exist");
        }

        _categoryRepository.DeleteAsync(categoryToDelete);

        await _categoryRepository.SaveAsync();
    }
}