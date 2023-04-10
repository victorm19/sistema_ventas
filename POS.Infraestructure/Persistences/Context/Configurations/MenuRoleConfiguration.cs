namespace POS.Infraestructure.Persistences.Context.Configurations;

public class MenuRoleConfiguration : IEntityTypeConfiguration<MenuRole>
{
    public void Configure(EntityTypeBuilder<MenuRole> builder)
    {
        builder.HasKey(e => e.MenuRolId)
                    .HasName("PK__MenuRole__6640AD0C702B4ADF");

        builder.HasOne(d => d.Menu)
            .WithMany(p => p.MenuRoles)
            .HasForeignKey(d => d.MenuId)
            .HasConstraintName("FK_MenuRoles_Menu");

        builder.HasOne(d => d.Role)
            .WithMany(p => p.MenuRoles)
            .HasForeignKey(d => d.RoleId)
            .HasConstraintName("FK_MenuRoles_Roles");
    }
}

