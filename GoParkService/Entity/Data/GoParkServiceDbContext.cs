using GoParkService.Entity.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GoParkService.Entity.Data;

public class GoParkServiceDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public GoParkServiceDbContext(DbContextOptions<GoParkServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure ApplicationUser and IdentityRole<Guid>
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("User");
        });

        builder.Entity<IdentityRole<Guid>>(entity =>
        {
            entity.ToTable("Role");
        });

        // Configure IdentityUserRole<Guid>
        builder.Entity<IdentityUserRole<Guid>>(entity =>
        {
            entity.HasKey(r => new { r.UserId, r.RoleId });
            entity.ToTable("UserRoles");
        });

        // Configure IdentityUserLogin<Guid>
        builder.Entity<IdentityUserLogin<Guid>>(entity =>
        {
            entity.HasKey(l => l.UserId);
            entity.ToTable("UserLogins");
        });

        // Configure IdentityUserClaim<Guid>
        builder.Entity<IdentityUserClaim<Guid>>(entity =>
        {
            entity.ToTable("UserClaims");
        });

        // Configure IdentityRoleClaim<Guid>
        builder.Entity<IdentityRoleClaim<Guid>>(entity =>
        {
            entity.ToTable("RoleClaims");
        });

        // Configure IdentityUserToken<Guid>
        builder.Entity<IdentityUserToken<Guid>>(entity =>
        {
            entity.HasKey(t => t.UserId);
            entity.ToTable("UserTokens");
        });
    }

}
