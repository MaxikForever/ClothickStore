using Clothick.Contracts.Interfaces.Services;

namespace Clothick.Domain.Entities;

public class Category : IEntity
{
    public int Id { get; set; }

    // Navigation property for related products
    public ICollection<Product> Products { get; set; }

    public string Name { get; set; }
}