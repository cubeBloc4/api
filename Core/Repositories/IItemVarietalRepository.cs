namespace Core;

public interface IItemVarietalRepository
{
    Task AddItemVarietal(ItemVarietalDto itemVarietalDto);
    Task<IEnumerable<ItemVarietalDto>> GetItemVarietals();
}
