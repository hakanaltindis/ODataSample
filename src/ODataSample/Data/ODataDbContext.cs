using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataSample.Entities;

namespace ODataSample.Data
{
  public class ODataDbContext : DbContext
  {
    public ODataDbContext(DbContextOptions<ODataDbContext> options)
      : base(options)
    {

    }

#nullable disable
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<CustomerActivity> CustomerActivities { get; set; }
#nullable enable

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema(Constants.Schema);

      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

      modelBuilder.Entity<Customer>().HasQueryFilter(c => !c.IsDeleted);

      base.OnModelCreating(modelBuilder);
    }

    public static IEdmModel GetEdmModel()
    {
      ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
      modelBuilder.EntitySet<Customer>("Customer");
      modelBuilder.EntitySet<Activity>("Activity");
      modelBuilder.EntitySet<CustomerActivity>("CustomerActivity");
      return modelBuilder.GetEdmModel();
    }
  }
}
