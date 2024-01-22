using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.DTO;

public class ProductUploadDto
{
    public string BrandName { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}