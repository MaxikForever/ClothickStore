using System.Data.Common;

namespace Clothick.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public Decimal TotalPrice { get; set; }
}