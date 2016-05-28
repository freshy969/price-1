using System.Collections.Generic;
using System.Linq;
using Data.Generic;

namespace Data.Entities.Item
{
    public class ItemRepository : GenericRepository<ItemEntity>, IItemRepository
    {
        /*public List<ItemEntity> GetTopNewestItems(int limit)
        {
            return GetAll().ToList();
        }*/

        public ItemEntity GetByUrl(string url)
        {
            return Session
                .QueryOver<ItemEntity>()
                .Where(c => c.Url == url)
                .SingleOrDefault();
        }
    }
}
