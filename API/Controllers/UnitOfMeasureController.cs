using System.Security.Permissions;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("[controller]")]
public class UnitOfMeasureController : ControllerBase
{
    private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;

    public UnitOfMeasureController(IUnitOfMeasureRepository unitOfMeasureRepository)
    {
        _unitOfMeasureRepository = unitOfMeasureRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<UnitOfMeasureDto>> GetUnitsOfMeasure()
    {
        return await _unitOfMeasureRepository.GetUnitOfMeasures();
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetUnitOfMeasureByCode(string code)
    {
        var unitOfMeasure = await _unitOfMeasureRepository.GetUnitOfMeasureByCode(code);
        if (unitOfMeasure == null)
        {
            return NotFound($"Unité de mesure avec le code '{code}' non trouvée.");
        }
        return Ok(unitOfMeasure);
    }

    [HttpPost]
    public async Task<IActionResult> AddUnitOfMeasure([FromBody] AddUOMRequest addUnitOfMeasureRequest)
    {
        if (addUnitOfMeasureRequest == null)
            return BadRequest("Le corps de la requête est vide.");

        try
        {
            await _unitOfMeasureRepository.AddUnitOfMeasure(new UnitOfMeasureDto
            {
                Code = addUnitOfMeasureRequest.Code
            });
            return Ok("Unité de mesure créée avec succès !");
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

    [HttpDelete("{code}")]
    public async Task<IActionResult> DeleteUnitOfMeasure(string code)
    {
        try
        {
            await _unitOfMeasureRepository.DeleteUnitOfMeasure(code);
            return Ok("Unité de mesure supprimée avec succès !");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPut("{code}")]
    public async Task<IActionResult> UpdateUnitOfMeasure(string code, [FromBody] UpdateUOMRequest updateUnitOfMeasureRequest)
    {
        if (updateUnitOfMeasureRequest == null)
            return BadRequest("Le corps de la requête est vide.");

        try
        {
            await _unitOfMeasureRepository.UpdateUnitOfMeasure(code, new UnitOfMeasureDto
            {
                Code = updateUnitOfMeasureRequest.Code
            });
            return Ok("Unité de mesure mise à jour avec succès !");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}
