namespace Clothick.Api.DTO;

public class GetProductVariantDto
{
    public string Size { get; set; }

    public string Color { get; set; }

    public int Stock { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public string SKU { get; set; }
}