namespace Clothick.Domain.Entities;

public class ProductImage
{
    public int Id { get; set; }

    public int ProductID { get; set; }

    public string ImageURL { get; set; }

    // Navigation property
    public  Product Product { get; set; }
}