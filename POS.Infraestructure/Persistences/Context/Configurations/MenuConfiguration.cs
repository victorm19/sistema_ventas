namespace POS.Infraestructure.Persistences.Context.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

        builder.Property(e => e.Name)
            .HasMaxLength(150)
            .IsUnicode(false);

        builder.Property(e => e.Url)
            .HasMaxLength(150)
            .IsUnicode(false)
            .HasColumnName("URL");
    }
}
