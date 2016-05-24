using System.Collections.Generic;
using Data.Generic;

namespace Data.Entities.Item
{
    public interface IItemRepository : IGenericRepository<ItemEntity>
    {
        //List<ItemEntity> GetTopNewestItems(int v);

        ItemEntity GetByUrl(string url);
    }
}
