namespace Clothick.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string BrandName { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime LastUpdated { get; set; }

    // Navigation properties

    public Category Category { get; set; }
    public ICollection<ProductVariant> ProductVariants { get; set; }
    public ICollection<ProductRating> ProductRatings { get; set; }
}