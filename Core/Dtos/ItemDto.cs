namespace Core;

public class ItemDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string BaseUOMCode { get; set; }
    public required decimal SalePricePerBaseUOM { get; set; }
    public required decimal PurchasePricePerBaseUOM { get; set; }
    public required decimal SecurityStock { get; set; }
    public ItemFamilyDto ItemFamily { get; set; } = null!;
    public List<ItemVarietalDto>? ItemVarietals { get; set; } = [];
    public List<ItemUnitOfMeasureDto>? ItemUOMs { get; set; } = [];
}
