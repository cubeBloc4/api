namespace Core;

public interface IItemRepository
{
    public Task AddItem(ItemDto item);
    public Task<ItemDto?> GetItemByName(string name);
    public Task<IEnumerable<ItemDto>> GetItems(SupplierDto? supplier, ItemFamilyDto? itemFamily, ItemVarietalDto? itemVarietal);
}
