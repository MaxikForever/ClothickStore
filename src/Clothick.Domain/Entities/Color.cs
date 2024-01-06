using Clothick.Contracts.Interfaces.Services;

namespace Clothick.Domain.Entities;

public class Color : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    // Navigation property for related product variants
    public  ICollection<ProductVariant> ProductVariants { get; set; }
}