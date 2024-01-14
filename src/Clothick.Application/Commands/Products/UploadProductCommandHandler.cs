using Clothick.Application.Extensions;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products;

public class UploadProductCommandHandler : IRequestHandler<UploadProductCommand, Product?>
{
    private readonly IProductImageStorageService _fileStorageService;
    private readonly IProductRatingService _productRatingService;
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IProductService _productService;
    private readonly IBaseRepository<ProductRating> _ratingRepository;

    public UploadProductCommandHandler(IBaseRepository<Product> productRepository, IProductService productService,
        IBaseRepository<ProductRating> ratingRepository, IProductRatingService productRatingService,
        IProductImageStorageService fileStorageService)
    {
        _productRepository = productRepository;
        _productService = productService;
        _ratingRepository = ratingRepository;
        _productRatingService = productRatingService;
        _fileStorageService = fileStorageService;
    }

    public async Task<Product?> Handle(UploadProductCommand request, CancellationToken cancellationToken)
    {
        var product = await request.ToEntity();

        _productRepository.CreateAsync(product);

        await _productRepository.SaveAsync();

        await _productRatingService.CreateInitialProductRatingAsync(product.Id);

        await _productRepository.SaveAsync();

        var savedProduct = await _productService.GetProduct(product.Id);

        await _productRepository.SaveAsync();

        return savedProduct;
    }
}