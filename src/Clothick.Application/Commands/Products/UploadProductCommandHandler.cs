using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products;

public class UploadProductCommandHandler : IRequestHandler<UploadProductCommand, Product?>
{
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IBaseRepository<ProductRating> _ratingRepository;
    private readonly IProductService _productService;
    private readonly IProductRatingService _productRatingService;

    public UploadProductCommandHandler(IBaseRepository<Product> productRepository, IProductService productService,
        IBaseRepository<ProductRating> ratingRepository, IProductRatingService productRatingService)
    {
        _productRepository = productRepository;
        _productService = productService;
        _ratingRepository = ratingRepository;
        _productRatingService = productRatingService;
    }

    public async Task<Product?> Handle(UploadProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.ToEntity();

        _productRepository.CreateAsync(product);

        await _productRepository.SaveAsync();

        await _productRatingService.CreateInitialProductRatingAsync(product.Id);

        await _productRepository.SaveAsync();

        var savedProduct = await _productService.GetProduct(product.Id);

        return savedProduct;
    }
}