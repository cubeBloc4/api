using Core;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class SupplierController : ControllerBase
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierController(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    [HttpGet("suppliers")]
    public async Task<IEnumerable<SupplierDto>> GetAllSuppliers()
    {
        var supplier = await _supplierRepository.GetAllSupplier();
        return supplier;
    }

    [HttpPost("suppliers")]
    public async Task<IActionResult> AddCustomer([FromBody] SupplierDto supplierDto)
    {
        if (supplierDto == null)
            return BadRequest("Le corps de la requête est vide.");

        try
        {
            await _supplierRepository.AddSupplier(supplierDto);
            return Ok("Fournisseur créé avec succès !");
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
