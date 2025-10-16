namespace Core;

public interface IUnitOfMeasureRepository
{
    Task AddUnitOfMeasure(UnitOfMeasureDto unitOfMeasureDto);
    Task<UnitOfMeasureDto?> GetUnitOfMeasureByCode(string code);
    Task<IEnumerable<UnitOfMeasureDto>> GetUnitOfMeasures();
    Task UpdateUnitOfMeasure(string code, UnitOfMeasureDto unitOfMeasureDto);
    Task DeleteUnitOfMeasure(string code);
}
