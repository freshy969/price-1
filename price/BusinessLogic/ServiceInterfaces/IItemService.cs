using Model.Item;
using System.Collections.Generic;

namespace BusinessLogic.ServiceInterfaces
{
    public interface IItemService
    {
        Item EnsureItemWithUnit(string itemDescription);
        List<ItemDto> GetAll();
    }
}
