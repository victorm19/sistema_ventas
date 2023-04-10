namespace POS.Infraestructure.Persistences.Context.Configurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

        builder.HasOne(d => d.Province)
            .WithMany(p => p.Districts)
            .HasForeignKey(d => d.ProvinceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Districts_Provinces");
    }
}
