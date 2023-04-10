namespace POS.Infraestructure.Persistences.Context.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
    }
}

