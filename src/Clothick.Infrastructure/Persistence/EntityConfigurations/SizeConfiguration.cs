using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clothick.Infrastructure.Persistence.EntityConfigurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        var sizes = new List<Size>
        {
            new Size { Id = 20, Name = "XXXL" },
            new Size { Id = 21, Name = "XXL" },
            new Size { Id = 22, Name = "XL" },
            new Size { Id = 23, Name = "L" },
            new Size { Id = 24, Name = "M" },
            new Size { Id = 25, Name = "S" },
            new Size { Id = 26, Name = "XS" }
        };

        int currentId = 27; // Starting ID for numeric sizes

        // Adding numeric sizes from 15 to 60
        for (int i = 15; i <= 60; i++)
        {
            sizes.Add(new Size { Id = currentId++, Name = i.ToString() });
        }

        builder.HasData(sizes);
    }
}