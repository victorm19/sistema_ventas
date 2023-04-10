namespace POS.Infraestructure.Persistences.Context.Configurations;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.Property(e => e.Abbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

        builder.Property(e => e.Code)
            .HasMaxLength(10)
            .IsUnicode(false);

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}
