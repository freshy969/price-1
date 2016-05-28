using Data.Generic;

namespace Data.Entities.Item
{
    public interface IItemRepository : IGenericRepository<ItemEntity>
    {
        ItemEntity GetByCode(string code);
        ItemEntity GetByText(string text);
    }
}
