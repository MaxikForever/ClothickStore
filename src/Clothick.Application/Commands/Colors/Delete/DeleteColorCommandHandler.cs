using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.CustomExceptions;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.UserRegistrationCommands.Colors.Delete;

public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand>
{
    private readonly IBaseRepository<Color> _colorsRepository;

    public DeleteColorCommandHandler(IBaseRepository<Color> colorsRepository)
    {
        _colorsRepository = colorsRepository;
    }

    public async Task Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _colorsRepository.FindByCondition(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (categoryToDelete is null)
        {
            throw new InvalidId("Color Id doesn't exist");
        }

        _colorsRepository.DeleteAsync(categoryToDelete);

        await _colorsRepository.SaveAsync();
    }
}