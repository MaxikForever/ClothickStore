using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.ProductVariant;

public class
    AddProductVariantsCommandHandler : IRequestHandler<AddProductVariantsCommand, Domain.Entities.ProductVariant>
{
    private readonly IBaseRepository<Domain.Entities.ProductVariant> _repository;

    public AddProductVariantsCommandHandler(IBaseRepository<Domain.Entities.ProductVariant> repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.ProductVariant> Handle(AddProductVariantsCommand request,
        CancellationToken cancellationToken)
    {
        var newProductVariant = request.ToEntity();

        _repository.CreateAsync(newProductVariant);

        await _repository.SaveAsync();

        var result = await _repository.FindByCondition(pv => pv.Id == newProductVariant.Id)
            .Include(pv => pv.Size)
            .Include(pv => pv.Color).FirstOrDefaultAsync();

        return result!;
    }
}