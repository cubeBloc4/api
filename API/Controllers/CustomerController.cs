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

    [HttpGet]
    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        var customer = await _customerRepository.GetAllCustomer();
        return customer;
    }

    [HttpPost]
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

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        var customer = await _customerRepository.GetCustomerById(id);
        if (customer == null) return NotFound();

        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        var DeleteCustomer = await _customerRepository.DeleteCustomer(id);
        if (!DeleteCustomer) return NotFound();

        return Ok("Supprimé");

    }
}
