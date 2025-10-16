namespace Core;

public interface ISupplierRepository
{
    public Task AddSupplier(SupplierDto supplier);
    public Task<IEnumerable<SupplierDto>> GetAllSupplier();
}
