namespace Clothick.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string BrandName { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string SKU { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime LastUpdated { get; set; }

    // Navigation properties

    public virtual Category Category { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; }
    public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    public virtual ICollection<ProductRating> ProductRatings { get; set; }
}