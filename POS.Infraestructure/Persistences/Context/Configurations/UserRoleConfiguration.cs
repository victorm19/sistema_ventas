﻿namespace POS.Infraestructure.Persistences.Context.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasOne(d => d.BranchOffice)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.BranchOfficeId)
                    .HasConstraintName("FK__UserRoles__Branc__5AEE82B9");

        builder.HasOne(d => d.Role)
            .WithMany(p => p.UserRoles)
            .HasForeignKey(d => d.RoleId)
            .HasConstraintName("FK__UserRoles__RoleI__5BE2A6F2");

        builder.HasOne(d => d.User)
            .WithMany(p => p.UserRoles)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK__UserRoles__UserI__5CD6CB2B");
    }
}

