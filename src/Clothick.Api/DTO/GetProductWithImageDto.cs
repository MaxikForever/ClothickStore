namespace Clothick.Api.DTO;

public class GetProductWithImageDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }

    public string Image { get; set; }
    public IEnumerable<GetProductRatingsDto> ProductRatings { get; set; }
}