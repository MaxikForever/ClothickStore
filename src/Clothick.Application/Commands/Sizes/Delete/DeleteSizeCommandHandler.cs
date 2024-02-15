using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.CustomExceptions;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.UserRegistrationCommands.Sizes.Delete;

public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommand>
{
    private readonly IBaseRepository<Size> _sizeRepository;

    public DeleteSizeCommandHandler(IBaseRepository<Size> sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }

    public async Task Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _sizeRepository.FindByCondition(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (categoryToDelete is null)
        {
            throw new InvalidId("Size Id doesn't exist");
        }

        _sizeRepository.DeleteAsync(categoryToDelete);

        await _sizeRepository.SaveAsync();
    }
}