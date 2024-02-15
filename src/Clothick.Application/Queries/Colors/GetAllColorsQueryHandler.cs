using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.Colors;

public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQuery, List<Color>>
{
    private readonly IBaseRepository<Color> _colorsRepository;

    public GetAllColorsQueryHandler(IBaseRepository<Color> colorsRepository)
    {
        _colorsRepository = colorsRepository;
    }

    public async Task<List<Color>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
    {
        var colors = await _colorsRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return colors;
    }
}