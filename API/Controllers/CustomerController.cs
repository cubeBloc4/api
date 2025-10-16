using System.Net.NetworkInformation;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("customers")]
    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        var customer = await _customerRepository.GetAllCustomer();
        return customer;
    }

    [HttpPost("customers")]
    public async Task<IActionResult> AddCustomer([FromBody] CustomerPasswordDto customerPassword)
    {
        if (customerPassword == null)
            return BadRequest("Le corps de la requête est vide.");

        try
        {
            await _customerRepository.AddCustomer(customerPassword);
            return Ok("Client créé avec succès !");
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }


}
