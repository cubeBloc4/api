namespace Core;

public interface IItemFamilyRepository
{
    Task AddItemFamily(ItemFamilyDto itemFamily);
    Task<ItemFamilyDto?> GetItemFamilyByName(string name);
    Task<IEnumerable<ItemFamilyDto>> GetItemFamilies(ItemDto? item);
}
