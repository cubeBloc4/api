namespace Infrastructure;

public class ItemEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string BaseUOMCode { get; set; }
    public required decimal SalePricePerBaseUOM { get; set; }
    public required decimal PurchasePricePerBaseUOM { get; set; }
    public required decimal SecurityStock { get; set; }
    public required int ItemFamilyId { get; set; }
    virtual public ItemFamilyEntity? ItemFamily { get; set; }
    virtual public List<ItemUnitOfMeasureEntity> ItemUOMs { get; set; } = [];
    virtual public List<ItemVarietalEntity> ItemVarietals { get; set; } = [];
}
