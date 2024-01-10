using MediatR;

namespace Clothick.Application.Commands.ProductVariant;

public record AddProductVariantsCommand(int SizeId, int ColorId, int Stock,  decimal? DiscountedPrice, string SKU, int ProductId) : IRequest<Domain.Entities.ProductVariant>;