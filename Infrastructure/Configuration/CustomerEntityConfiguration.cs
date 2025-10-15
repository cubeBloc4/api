using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("Customer");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).HasColumnName("firstname").IsRequired();
        builder.Property(c => c.LastName).HasColumnName("lastname").IsRequired();
        builder.Property(c => c.UserName).HasColumnName("username").IsRequired();
        builder.Property(c => c.HashPassword).HasColumnName("hashpassword").IsRequired();
        builder.Property(c => c.Email).HasColumnName("email").IsRequired();
        builder.Property(c => c.Address1).HasColumnName("address1");
        builder.Property(c => c.Address2).HasColumnName("address2");
        builder.Property(c => c.City).HasColumnName("city");
        builder.Property(c => c.ZipCode).HasColumnName("zipcode");
        builder.Property(c => c.Country).HasColumnName("country");
    }
}
