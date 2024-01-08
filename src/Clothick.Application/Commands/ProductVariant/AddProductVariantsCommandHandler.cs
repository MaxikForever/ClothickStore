using MediatR;

namespace Clothick.Application.Commands.ProductVariant;

public class AddProductVariantsCommandHandler : IRequestHandler<AddProductVariantsCommand,Domain.Entities.ProductVariant>
{
    public async Task<Domain.Entities.ProductVariant> Handle(AddProductVariantsCommand request, CancellationToken cancellationToken)
    {

    }
}