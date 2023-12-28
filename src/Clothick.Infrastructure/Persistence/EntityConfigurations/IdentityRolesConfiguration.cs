using Clothick.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clothick.Infrastructure.Persistence.EntityConfigurations;

public class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.HasData(
            new IdentityRole<Guid>
                { Id = Guid.NewGuid(), Name = RolesConstants.User, NormalizedName = RolesConstants.User.ToUpper() },
            new IdentityRole<Guid>
                { Id = Guid.NewGuid(), Name = RolesConstants.Admin, NormalizedName = RolesConstants.Admin.ToUpper() },
            new IdentityRole<Guid>
                { Id = Guid.NewGuid(), Name = RolesConstants.Guest, NormalizedName = RolesConstants.Guest.ToUpper() }
        );
    }
}