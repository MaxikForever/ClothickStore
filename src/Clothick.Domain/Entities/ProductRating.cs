namespace Clothick.Domain.Entities;

public class ProductRating
{
    public int Id { get; set; }

    public int ProductID { get; set; }

    public decimal StarRating { get; set; }

    public string Comment { get; set; }

    public DateTime DatePosted { get; set; }

    // Navigation property
    public virtual Product Product { get; set; }
}