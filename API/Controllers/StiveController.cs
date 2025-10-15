using System.Net.NetworkInformation;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("[controller]")]

public class StiveController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public StiveController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("customers")]
    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        var customer = await _customerRepository.GetAllCustomer();
        return customer;
    }

}
