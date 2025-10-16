using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UnitOfMeasureEntityConfiguration : IEntityTypeConfiguration<UnitOfMeasureEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UnitOfMeasureEntity> builder)
    {
        builder.ToTable("UnitOfMeasure");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
        builder.Property(u => u.Code).HasColumnName("code").IsRequired().HasMaxLength(10);
    }
}