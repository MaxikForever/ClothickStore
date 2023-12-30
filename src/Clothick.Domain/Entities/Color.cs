namespace Clothick.Domain.Entities;

public class Color
{
    public int Id { get; set; }

    public string ColorName { get; set; }

    // Navigation property for related product variants
    public virtual ICollection<ProductVariant> ProductVariants { get; set; }
}