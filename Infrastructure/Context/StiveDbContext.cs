using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class StiveDbContext : DbContext
{
    public StiveDbContext(DbContextOptions<StiveDbContext> options) : base(options)
    {
    }
    public DbSet<CustomerEntity> Customer { get; set; } = null!;
    public DbSet<SupplierEntity> Supplier { get; set; } = null!;
    public DbSet<UnitOfMeasureEntity> UnitOfMeasure { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UnitOfMeasureEntityConfiguration());
    }
}
