using Model.Item;

namespace BusinessLogic.ServiceInterfaces
{
    public interface IItemService
    {
        ItemData GetItem(int id);
    }
}
