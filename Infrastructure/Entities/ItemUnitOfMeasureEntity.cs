namespace Infrastructure;

public class ItemUnitOfMeasureEntity
{
    public int ItemId { get; set; }
    public string UOMCode { get; set; } = string.Empty;
    virtual public UnitOfMeasureEntity? UnitOfMeasure { get; set; }
    public decimal QuantityPerBaseUOM { get; set; }
}
