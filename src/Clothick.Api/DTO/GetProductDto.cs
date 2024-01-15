namespace Clothick.Api.DTO;

public class GetProductDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public IEnumerable<GetProductRatingsDto> ProductRatings { get; set; }
}