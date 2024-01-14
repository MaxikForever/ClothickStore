using MediatR;
using Microsoft.AspNetCore.Http;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products;

public record UploadProductVariantCommand
(int ProductId,
    int SizeId,
    int ColorId,
    int Stock,
    decimal? DiscountedPrice,
    string SKU,
    List<IFormFile> Images
) : IRequest<Domain.Entities.ProductVariant>;