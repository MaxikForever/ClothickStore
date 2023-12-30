namespace Clothick.Domain.Entities;

public class Size
{
    public int Id { get; set; }

    public string SizeName { get; set; }

    // Navigation property for related product variants
    public virtual ICollection<ProductVariant> ProductVariants { get; set; }
}