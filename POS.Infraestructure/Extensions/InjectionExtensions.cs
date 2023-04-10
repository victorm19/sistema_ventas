namespace POS.Infraestructure.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(POSContext).Assembly.FullName;

        services.AddDbContext<POSContext>(
                options => options.UseSqlServer(
                        configuration.GetConnectionString("POSConnection"),
                        b => b.MigrationsAssembly(assembly)
                    ),
                ServiceLifetime.Transient
            );

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

