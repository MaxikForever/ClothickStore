using Clothick.Domain.Entities;
using Microsoft.Extensions.Primitives;
using HostingEnvironmentExtensions = Microsoft.Extensions.Hosting.HostingEnvironmentExtensions;

namespace Clothick.Api.DTO;

public class GetProductDto
{
    public string BrandName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }

    public IEnumerable<GetProductVariantDto> ProductVariants { get; set; }

    public IEnumerable<string> ImageURLs { get; set; }

    public IEnumerable<GetProductRatingsDto> ProductRatings { get; set; }
}