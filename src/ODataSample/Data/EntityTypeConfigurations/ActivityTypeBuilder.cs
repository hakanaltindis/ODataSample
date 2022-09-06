using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataSample.Entities;

namespace ODataSample.Data.EntityTypeConfigurations
{
  public class ActivityTypeBuilder : IEntityTypeConfiguration<Activity>
  {
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
      builder
        .HasKey(a => a.Id);

      builder
        .Property(a => a.IsDeleted)
        .HasDefaultValue(false);

      builder
        .Property(a => a.Name)
        .HasMaxLength(100)
        .IsRequired();

      builder
        .Property(a => a.Description)
        .HasMaxLength(255)
        .IsRequired();

      builder.HasData(
        new Activity { Id = 1, Name = "October Fest", Description = "Description", IsDeleted = false },
        new Activity { Id = 2, Name = "Kurban Bayramı", Description = "Description", IsDeleted = false },
        new Activity { Id = 3, Name = "Ramazan Bayramı", Description = "Description", IsDeleted = false },
        new Activity { Id = 4, Name = "Yılbaşı", Description = "Description", IsDeleted = false },
        new Activity { Id = 5, Name = "23 Nisan Ulusal Egemenlik ve Çocuk Bayramı", Description = "Description", IsDeleted = false }
      );
    }
  }
}
