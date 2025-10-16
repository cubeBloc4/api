namespace Core;

public interface IItemUOMInterface
{
    Task AddItemUOM(ItemUnitOfMeasureDto itemUOM);
    Task<IEnumerable<ItemUnitOfMeasureDto>> GetItemUOMs(ItemDto? item);
}
