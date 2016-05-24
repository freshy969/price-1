using Data.Entities.Item;
using Model.Item;

namespace BusinessLogic.Mappers
{
    internal class ItemMapper
    {
        internal static ItemData MapToLinkModel(ItemEntity Item)
        {
            return new ItemData()
            {
                Id = Item.Id,
                Url = Item.Url,
                Text = Item.Text
            };
        }
    }
}
