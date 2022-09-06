using Microsoft.EntityFrameworkCore;

namespace ODataSample
{
  public static class IApplicationBuilderExtensions
  {
    public static void ApplyMigration<TDbContext>(this IApplicationBuilder builder)
      where TDbContext : DbContext
    {
      using var scope = builder.ApplicationServices.CreateScope();

      var context = scope.ServiceProvider.GetRequiredService<TDbContext>();

      context.Database.Migrate();
    }
  }

  public static class IServiceCollectionExtensions
  {
    public static IServiceCollection RegisterDbContext<TDbContext>(this IServiceCollection services, IConfiguration configuration)
      where TDbContext : DbContext
    {

      var defaultConnection = configuration.GetConnectionString("Default");

      ValidateEnvironmentVariable("Default", defaultConnection);

      services.AddDbContext<TDbContext>(opt =>
      {
        opt.UseNpgsql(defaultConnection, sql =>
        {
          sql.MigrationsAssembly(typeof(TDbContext).Assembly.GetName().Name);
          sql.MigrationsHistoryTable("__EFMigrationsHistory", Constants.Schema);
        });
      });

      return services;
    }

    private static void ValidateEnvironmentVariable(string nameOfVariable, string? valueOfVariable)
    {
      if (string.IsNullOrWhiteSpace(valueOfVariable))
      {
        throw new ArgumentNullException(nameOfVariable, $"The {nameOfVariable} must be passed in Environment Variables");
      }
    }
  }
}
