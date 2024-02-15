using Clothick.Contracts.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.Size.GetAll;

public class GetAllSizesHandler : IRequestHandler<GetAllSizesQuery, List<Domain.Entities.Size>>
{
    private readonly IBaseRepository<Domain.Entities.Size> _sizeRepository;

    public GetAllSizesHandler(IBaseRepository<Domain.Entities.Size> sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }

    public async Task<List<Domain.Entities.Size>> Handle(GetAllSizesQuery request, CancellationToken cancellationToken)
    {
        var sizes = await  _sizeRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return sizes;
    }
}