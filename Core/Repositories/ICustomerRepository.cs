namespace Core;

public interface ICustomerRepository
{
    public Task AddCustomer(CustomerPasswordDto customerPassword);
    public Task<IEnumerable<CustomerDto>> GetAllCustomer();
    public Task<CustomerDto?> GetCustomerById(int id);
    public Task<bool> UpdateCustomer(int id, CustomerDto customer);
    public Task<bool> DeleteCustomer(int id);
    public Task<bool> UpdateCustomerPassword(int id, CustomerPasswordDto customerPassword);
}
