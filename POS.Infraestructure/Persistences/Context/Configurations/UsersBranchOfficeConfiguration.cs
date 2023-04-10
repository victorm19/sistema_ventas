﻿namespace POS.Infraestructure.Persistences.Context.Configurations;

public class UsersBranchOfficeConfiguration : IEntityTypeConfiguration<UsersBranchOffice>
{
    public void Configure(EntityTypeBuilder<UsersBranchOffice> builder)
    {
        builder.HasKey(e => e.UserBranchOfficeId)
                    .HasName("PK__UsersBra__7D1E804A5C31AD8A");

        builder.HasOne(d => d.BranchOffice)
            .WithMany(p => p.UsersBranchOffices)
            .HasForeignKey(d => d.BranchOfficeId)
            .HasConstraintName("FK__UsersBran__Branc__5DCAEF64");

        builder.HasOne(d => d.User)
            .WithMany(p => p.UsersBranchOffices)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK__UsersBran__UserI__5EBF139D");
    }
}

