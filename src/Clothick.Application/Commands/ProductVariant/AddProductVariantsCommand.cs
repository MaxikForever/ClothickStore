using MediatR;

namespace Clothick.Application.Commands.ProductVariant;

public record AddProductVariantsCommand(int SizeId, int ColorId, int Stock,  decimal? DiscountedPrice, string SKU) : IRequest<Domain.Entities.ProductVariant>;