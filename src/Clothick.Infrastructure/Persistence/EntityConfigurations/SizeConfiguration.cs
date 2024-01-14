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
            new() { Id = 20, Name = "XXXL" },
            new() { Id = 21, Name = "XXL" },
            new() { Id = 22, Name = "XL" },
            new() { Id = 23, Name = "L" },
            new() { Id = 24, Name = "M" },
            new() { Id = 25, Name = "S" },
            new() { Id = 26, Name = "XS" }
        };

        var currentId = 27; // Starting ID for numeric sizes

        // Adding numeric sizes from 15 to 60
        for (var i = 15; i <= 60; i++) sizes.Add(new Size { Id = currentId++, Name = i.ToString() });

        builder.HasData(sizes);
    }
}