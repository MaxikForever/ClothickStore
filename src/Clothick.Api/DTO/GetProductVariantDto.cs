namespace Clothick.Api.DTO;

public class GetProductVariantDto
{
    public int Id { get; set; }
    public string Size { get; set; }

    public string Color { get; set; }

    public int Stock { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public string SKU { get; set; }

    public List<string> Images { get; set; }
}