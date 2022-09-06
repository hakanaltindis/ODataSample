using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataSample.Entities;

namespace ODataSample.Data.EntityTypeConfigurations
{
  public class CustomerTypeBuilder : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder
        .HasKey(c => c.Id);

      builder
        .Property(c => c.IsDeleted)
        .HasDefaultValue(false);

      builder
        .Property(c => c.FirstName)
        .HasMaxLength(100)
        .IsRequired();

      builder
        .Property(c => c.LastName)
        .HasMaxLength(100)
        .IsRequired();

      //builder.HasMany(c => c.CustomerActivities).WithOne(ca => ca.Customer).IsRequired();

      builder.HasData(
        new Customer { Id = 1, FirstName = "Hakan", LastName = "Altındiş", IsDeleted = false },
        new Customer { Id = 2, FirstName = "John", LastName = "Deere", IsDeleted = false },
        new Customer { Id = 3, FirstName = "Joe", LastName = "Smith", IsDeleted = true },
        new Customer { Id = 4, FirstName = "Sezen", LastName = "Altındiş", IsDeleted = false }
      );
    }
  }
}
