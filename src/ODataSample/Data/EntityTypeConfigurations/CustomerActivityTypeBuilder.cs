using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataSample.Entities;

namespace ODataSample.Data.EntityTypeConfigurations
{
  public class CustomerActivityTypeBuilder : IEntityTypeConfiguration<CustomerActivity>
  {
    public void Configure(EntityTypeBuilder<CustomerActivity> builder)
    {
      builder
        .HasKey(a => a.Id);

      builder
        .Property(a => a.IsDeleted)
        .HasDefaultValue(false);

      builder
        .HasOne(ca => ca.Customer)
        .WithMany(ca => ca.CustomerActivities)
        .HasForeignKey(ca => ca.CustomerId);

      builder
        .HasOne(ca => ca.Activity)
        .WithMany(ca => ca.CustomerActivities)
        .HasForeignKey(ca => ca.ActivityId);

      builder.HasOne(ac => ac.Customer).WithMany(ac => ac.CustomerActivities).IsRequired();

      builder.HasData(
        new CustomerActivity { Id = 1, CustomerId = 1, ActivityId = 1 },
        new CustomerActivity { Id = 2, CustomerId = 1, ActivityId = 2 },
        new CustomerActivity { Id = 3, CustomerId = 1, ActivityId = 4 },
        new CustomerActivity { Id = 4, CustomerId = 2, ActivityId = 1 },
        new CustomerActivity { Id = 5, CustomerId = 1, ActivityId = 3 },
        new CustomerActivity { Id = 6, CustomerId = 1, ActivityId = 5 },
        new CustomerActivity { Id = 7, CustomerId = 3, ActivityId = 1 },
        new CustomerActivity { Id = 8, CustomerId = 3, ActivityId = 3 },
        new CustomerActivity { Id = 9, CustomerId = 4, ActivityId = 2 },
        new CustomerActivity { Id = 10, CustomerId = 4, ActivityId = 1 },
        new CustomerActivity { Id = 11, CustomerId = 4, ActivityId = 4 }
      );
    }
  }
}
