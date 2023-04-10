namespace POS.Infraestructure.Persistences.Context.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
    }
}
