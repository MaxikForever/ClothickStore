namespace Clothick.Api.DTO;

public class ProductUploadDto
{
    public string BrandName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public List<UploadProductVariantDto> Variants { get; set; }
    public List<string> ImageURLs { get; set; }
}