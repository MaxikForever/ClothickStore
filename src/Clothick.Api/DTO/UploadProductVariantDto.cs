namespace Clothick.Api.DTO;

public class UploadProductVariantDto
{
    public int SizeId { get; set; }

    public int ColorId { get; set; }

    public int Stock { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public string SKU { get; set; }

    public List<IFormFile> Images { get; set; }
}