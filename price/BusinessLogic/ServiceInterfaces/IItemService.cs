using Model.Item;

namespace BusinessLogic.ServiceInterfaces
{
    public interface IItemService
    {
        Item EnsureItemWithUnit(string itemDescription);
    }
}
