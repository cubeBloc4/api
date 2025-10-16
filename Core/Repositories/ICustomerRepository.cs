namespace Core;

public interface ICustomerRepository
{
    public Task AddCustomer(CustomerPasswordDto customerPassword);
    public Task<IEnumerable<CustomerDto>> GetAllCustomer();
}
