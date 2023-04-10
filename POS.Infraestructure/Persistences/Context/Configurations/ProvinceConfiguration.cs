﻿namespace POS.Infraestructure.Persistences.Context.Configurations;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

        builder.HasOne(d => d.Department)
            .WithMany(p => p.Provinces)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Provinces__Depar__52593CB8");
    }
}

