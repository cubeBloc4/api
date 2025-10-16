using Core;
using Infrastructure.Context;

namespace Infrastructure;

public class UnitOfMeasureRepository : IUnitOfMeasureRepository
{
    public readonly StiveDbContext _context;

    public UnitOfMeasureRepository(StiveDbContext context)
    {
        _context = context;
    }

    public async Task AddUnitOfMeasure(UnitOfMeasureDto unitOfMeasureDto)
    {
        if (_context.UnitOfMeasure.Any(u => u.Code.ToLower() == unitOfMeasureDto.Code.ToLower()))
        {
            throw new InvalidOperationException($"Une unité de mesure avec le code '{unitOfMeasureDto.Code}' existe déjà.");
        }
        _context.UnitOfMeasure.Add(new UnitOfMeasureEntity
        {
            Code = unitOfMeasureDto.Code
        });

        await _context.SaveChangesAsync();
    }

    public async Task DeleteUnitOfMeasure(string code)
    {
        var entity = _context.UnitOfMeasure.FirstOrDefault(u => u.Code.ToLower() == code.ToLower());
        if (entity != null)
        {
            _context.UnitOfMeasure.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<UnitOfMeasureDto?> GetUnitOfMeasureByCode(string code)
    {
        var entity = _context.UnitOfMeasure.FirstOrDefault(u => u.Code.ToLower() == code.ToLower());
        if (entity == null)
        {
            return Task.FromResult<UnitOfMeasureDto?>(null);
        }

        return Task.FromResult<UnitOfMeasureDto?>(new UnitOfMeasureDto
        {
            Code = entity.Code
        });
    }

    public Task<IEnumerable<UnitOfMeasureDto>> GetUnitOfMeasures()
    {
        var entities = _context.UnitOfMeasure.ToList();
        var dtos = entities.Select(u => new UnitOfMeasureDto
        {
            Code = u.Code
        });

        return Task.FromResult(dtos);
    }

    public Task UpdateUnitOfMeasure(string code, UnitOfMeasureDto unitOfMeasureDto)
    {
        var entity = _context.UnitOfMeasure.FirstOrDefault(u => u.Code.ToLower() == code.ToLower());
        if (entity != null)
        {
            entity.Code = unitOfMeasureDto.Code;
            _context.UnitOfMeasure.Update(entity);
            _context.SaveChanges();
        }

        return Task.CompletedTask;
    }
}
