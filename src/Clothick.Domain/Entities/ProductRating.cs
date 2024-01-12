using System.ComponentModel.DataAnnotations;

namespace Clothick.Domain.Entities;

public class ProductRating
{
    public int Id { get; set; }

    public int ProductID { get; set; }
    public decimal StarRating { get; set; }

    public DateTime DatePosted { get; set; }

    // Navigation property
    public Product Product { get; set; }

    public ICollection<Comment> Comments { get; set; }
}