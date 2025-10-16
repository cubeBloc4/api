using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class StiveDbContext : DbContext
{
    public StiveDbContext(DbContextOptions<StiveDbContext> options) : base(options)
    {
    }
    public DbSet<CustomerEntity> Customer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
    }
}
