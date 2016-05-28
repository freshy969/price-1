using Data.Generic;

namespace Data.Entities.Item
{
    public class ItemRepository : GenericRepository<ItemEntity>, IItemRepository
    {
        public ItemEntity GetByCode(string code)
        {
            return Session
                .QueryOver<ItemEntity>()
                .Where(c => c.Code == code)
                .SingleOrDefault();
        }

        public ItemEntity GetByText(string text)
        {
            return Session
                .QueryOver<ItemEntity>()
                .Where(c => c.Text == text)
                .SingleOrDefault();
        }
    }
}
