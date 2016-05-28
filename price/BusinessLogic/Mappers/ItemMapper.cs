using Data.Entities.Item;
using Model.Item;

namespace BusinessLogic.Mappers
{
    internal class ItemMapper
    {
        internal static Item MapToModel(ItemEntity item)
        {
            return new Item()
            {
                Id = item.Id,
                Code = item.Code,
                Name = item.Text,
                Unit = item.Unit
            };
        }
    }
}
