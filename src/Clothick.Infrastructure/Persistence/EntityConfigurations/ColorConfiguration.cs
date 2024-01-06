using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clothick.Infrastructure.Persistence.EntityConfigurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasData(
            new Color { Id = 20, Name = "Black" },
            new Color { Id = 21, Name = "White" },
            new Color { Id = 22, Name = "Red" },
            new Color { Id = 23, Name = "Blue" },
            new Color { Id = 24, Name = "Green" },
            new Color { Id = 25, Name = "Yellow" },
            new Color { Id = 26, Name = "Purple" },
            new Color { Id = 27, Name = "Orange" },
            new Color { Id = 28, Name = "Pink" },
            new Color { Id = 29, Name = "Gray" },
            new Color { Id = 30, Name = "Brown" },
            new Color { Id = 31, Name = "Beige" },
            new Color { Id = 32, Name = "Maroon" },
            new Color { Id = 33, Name = "Navy" },
            new Color { Id = 34, Name = "Olive" }
        );
    }
}