namespace Clothick.Domain.Entities;

public class Image
{
    public int Id { get; set; }

    public string ImagePath { get; set; }

    //Navigation Properties
    public ProductVariant ProductVariant { get; set; }
}