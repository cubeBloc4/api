using Core;

namespace Infrastructure;

public class SupplierRepository : ISupplierRepository
{
    public Task AddSupplier(SupplierDto supplier)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SupplierDto>> GetAllSupplier()
    {
        throw new NotImplementedException();
    }
}
