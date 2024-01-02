namespace Clothick.Domain.Entities;

public class Color
{
    public int Id { get; set; }

    public string Name { get; set; }

    // Navigation property for related product variants
    public  ICollection<ProductVariant> ProductVariants { get; set; }
}