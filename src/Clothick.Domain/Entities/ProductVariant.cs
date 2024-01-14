using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace Clothick.Domain.Entities;

public class ProductVariant
{
    public int Id { get; set; }

    public int ProductID { get; set; }

    public int SizeID { get; set; }

    public int ColorID { get; set; }

    public int Stock { get; set; }

    public decimal? DiscountedPrice { get; set; } // Nullable for cases with no discount

    public string SKU { get; set; }

    public int ImageId { get; set; }

    // Navigation properties
    public ICollection<Image> Images { get; set; }

    public Product Product { get; set; }
    public Size Size { get; set; }
    public Color Color { get; set; }
}