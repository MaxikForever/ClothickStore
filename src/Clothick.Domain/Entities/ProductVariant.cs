namespace Clothick.Domain.Entities;

public class ProductVariant
{
    public int Id { get; set; }

    public int ProductID { get; set; }

    public int SizeID { get; set; }

    public int ColorID { get; set; }

    public int Stock { get; set; }

    public decimal? DiscountedPrice { get; set; } // Nullable for cases with no discount

    // Navigation properties
    public virtual Product Product { get; set; }
    public virtual Size Size { get; set; }
    public virtual Color Color { get; set; }
}