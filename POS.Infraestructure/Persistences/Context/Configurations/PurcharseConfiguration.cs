﻿namespace POS.Infraestructure.Persistences.Context.Configurations;

public class PurcharseConfiguration : IEntityTypeConfiguration<Purcharse>
{
    public void Configure(EntityTypeBuilder<Purcharse> builder)
    {
        builder.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

        builder.Property(e => e.Total).HasColumnType("decimal(18, 2)");

        builder.HasOne(d => d.Provider)
            .WithMany(p => p.Purcharses)
            .HasForeignKey(d => d.ProviderId)
            .HasConstraintName("FK__Purcharse__Provi__5535A963");

        builder.HasOne(d => d.User)
            .WithMany(p => p.Purcharses)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK__Purcharse__UserI__5629CD9C");
    }
}

