namespace Clothick.Api.DTO;

public class GetCommentDto
{
    public string Content { get; set; }

    public decimal StarRating { get; set; }

    public DateTime DatePosted { get; set; }

    public string UserName { get; set; }
}