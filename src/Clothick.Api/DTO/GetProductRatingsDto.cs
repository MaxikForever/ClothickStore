using Clothick.Domain.Entities;

namespace Clothick.Api.DTO;

public class GetProductRatingsDto
{
    public decimal StarRating { get; set; }

    public DateTime DatePosted { get; set; }
}