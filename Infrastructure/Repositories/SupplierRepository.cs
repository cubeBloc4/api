using Core;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SupplierRepository : ISupplierRepository
{
    private readonly StiveDbContext _stiveDbContext;

    public SupplierRepository(StiveDbContext stiveDbContext)
    {
        _stiveDbContext = stiveDbContext;
    }

    public async Task AddSupplier(SupplierDto supplier)
    {
        if (await _stiveDbContext.Supplier.AnyAsync(c => c.Name1 == supplier.Email))
        {
            throw new InvalidOperationException("Ce compte existe déjà");
        }

        var Supplier = new SupplierEntity
        {
            Name1 = supplier.Name1,
            Name2 = supplier.Name2,
            Email = supplier.Email,
            Address1 = supplier.Address1,
            Address2 = supplier.Address2,
            City = supplier.City,
            ZipCode = supplier.ZipCode,
            Country = supplier.Country
        };

        _stiveDbContext.Supplier.Add(Supplier);
        await _stiveDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<SupplierDto>> GetAllSupplier()
    {
        var Suppliers = await _stiveDbContext.Supplier.ToListAsync();

        return Suppliers.Select(b => new SupplierDto
        {
            Name1 = b.Name1,
            Name2 = b.Name2,
            Email = b.Email,
            Address1 = b.Address1,
            Address2 = b.Address2,
            City = b.City,
            ZipCode = b.ZipCode,
            Country = b.Country
        });
    }
}
