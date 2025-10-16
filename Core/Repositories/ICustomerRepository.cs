namespace Core;

public interface IUOMRepository
{
    public Task AddCustomer(CustomerPasswordDto customerPassword);
    public Task<IEnumerable<CustomerDto>> GetAllCustomer();
}
