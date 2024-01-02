namespace Clothick.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime DatePosted { get; set; }

    public int ProductRatingId { get; set; }
    public ProductRating ProductRating { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}