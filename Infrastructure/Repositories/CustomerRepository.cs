using Core;

namespace Infrastructure;

public class CustomerRepository : ICustomerRepository
{
    public Task AddCustomer(CustomerPasswordDto customerPassword)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerDto>> GetAllCustomer()
    {
        throw new NotImplementedException();
    }
}
