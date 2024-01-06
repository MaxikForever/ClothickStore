using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clothick.Infrastructure.Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category { Id = 20, Name = "Pants" },
            new Category { Id = 21, Name = "Shoes" },
            new Category { Id = 22, Name = "Shirts" },
            new Category { Id = 23, Name = "T-Shirts" },
            new Category { Id = 24, Name = "Jackets" },
            new Category { Id = 25, Name = "Sweaters" },
            new Category { Id = 26, Name = "Dresses" },
            new Category { Id = 27, Name = "Skirts" },
            new Category { Id = 28, Name = "Shorts" },
            new Category { Id = 29, Name = "Socks" },
            new Category { Id = 30, Name = "Hats" },
            new Category { Id = 31, Name = "Scarves" },
            new Category { Id = 32, Name = "Belts" },
            new Category { Id = 33, Name = "Gloves" },
            new Category { Id = 34, Name = "Sunglasses" }
        );
    }
}