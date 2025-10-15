using Core;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CustomerRepository : ICustomerRepository
{
    private readonly StiveDbContext _stiveDbContext;

    public CustomerRepository(StiveDbContext stiveDbContext)
    {
        _stiveDbContext = stiveDbContext;
    }

    public Task AddCustomer(CustomerPasswordDto customerPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomer()
    {
        var Customers = await _stiveDbContext.Customers.ToListAsync();

        return Customers.Select(b => new CustomerDto
        {
            FirstName = b.FirstName,
            LastName = b.LastName,
            UserName = b.UserName,
            Email = b.Email,
            Address1 = b.Address1,
            Address2 = b.Address2,
            City = b.City,
            ZipCode = b.ZipCode,
            Country = b.Country
        });
    }
}
