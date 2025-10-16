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

    public async Task AddCustomer(CustomerPasswordDto customerPassword)
    {
        if (await _stiveDbContext.Customer.AnyAsync(c => c.UserName == customerPassword.UserName || c.Email == customerPassword.Email))
        {
            throw new InvalidOperationException("Ce compte existe déjà");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(customerPassword.Password);

        var customer = new CustomerEntity
        {
            FirstName = customerPassword.FirstName,
            LastName = customerPassword.LastName,
            UserName = customerPassword.UserName,
            HashedPassword = hashedPassword,
            Email = customerPassword.Email,
            Address1 = customerPassword.Address1,
            Address2 = customerPassword.Address2,
            City = customerPassword.City,
            ZipCode = customerPassword.ZipCode,
            Country = customerPassword.Country
        };

        _stiveDbContext.Customer.Add(customer);
        await _stiveDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomer()
    {
        var Customers = await _stiveDbContext.Customer.ToListAsync();

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
