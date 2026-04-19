using hyBookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hyBookify.Infrastructure.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(role => role.Id);

        builder.HasMany(role => role.Permissions)
             .WithMany()
             .UsingEntity<RolePermission>();

        builder.HasData(Role.Registered);
        
        builder.HasMany(r => r.Users)
            .WithMany(u => u.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "RoleUser",
                j => j.HasOne<User>().WithMany().HasForeignKey("UsersId")
                      .HasConstraintName("fk_role_user_user_users_id"),
                j => j.HasOne<Role>().WithMany().HasForeignKey("RolesId")
                      .HasConstraintName("fk_role_user_role_roles_id")
            );
    }
}