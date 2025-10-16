using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class SupplierEntityConfiguration : IEntityTypeConfiguration<SupplierEntity>
{
    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.ToTable("Supplier");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name1).HasColumnName("name1").IsRequired();
        builder.Property(c => c.Name2).HasColumnName("name2").IsRequired();
        builder.Property(c => c.Email).HasColumnName("email").IsRequired();
        builder.Property(c => c.Address1).HasColumnName("address1");
        builder.Property(c => c.Address2).HasColumnName("address2");
        builder.Property(c => c.City).HasColumnName("city");
        builder.Property(c => c.ZipCode).HasColumnName("zipcode");
        builder.Property(c => c.Country).HasColumnName("country");
    }
}
