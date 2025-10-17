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

    public async Task<bool> DeleteCustomer(int id)
    {
        var customer = await _stiveDbContext.Customer.FindAsync(id);
        if (customer == null) return false;

        _stiveDbContext.Customer.Remove(customer);
        await _stiveDbContext.SaveChangesAsync();
        return true;
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

    public async Task<CustomerDto?> GetCustomerById(int id)
    {
        var c = await _stiveDbContext.Customer.FindAsync(id);
        if (c == null) return null;

        return new CustomerDto
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            UserName = c.UserName,
            Email = c.Email,
            Address1 = c.Address1,
            Address2 = c.Address2,
            City = c.City,
            ZipCode = c.ZipCode,
            Country = c.Country
        };
    }

    public async Task<bool> UpdateCustomer(int id, CustomerDto customerDto)
    {
        var customer = await _stiveDbContext.Customer.FindAsync(id);
        if (customer == null) return false;

        customer.FirstName = customerDto.FirstName;
        customer.LastName = customerDto.LastName;
        customer.Email = customerDto.Email;
        customer.UserName = customerDto.UserName;
        customer.Address1 = customerDto.Address1;
        customer.Address2 = customerDto.Address2;
        customer.City = customerDto.City;
        customer.ZipCode = customerDto.ZipCode;
        customer.Country = customerDto.Country;

        await _stiveDbContext.SaveChangesAsync();
        return true;
    }
}
